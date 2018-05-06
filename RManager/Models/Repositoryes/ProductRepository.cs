using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class ProductRepository
    {
        static ModelContainer cont = new ModelContainer();

        public ProductRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<Product> Products()
        {
            return cont.Product.OrderBy(c => c.Id);
        }

        public Product GetProductById(int id)
        {
            return cont.Product.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Product> GetProductsByName(string name)
        {
            return cont.Product.ToList().FindAll(p => p.Name == name);
        }

        public IEnumerable<Product> GetProductsByName(string name, IEnumerable<Product> products)
        {
            return products.ToList().FindAll(p => p.Name == name);
        }

        public IEnumerable<Product> GetProductsByProperty(string property)
        {
            return cont.Product.ToList().FindAll(p => p.Property == property);
        }

        public IEnumerable<Product> GetProductsByProperty(string property, IEnumerable<Product> products)
        {
            return products.ToList().FindAll(p => p.Property == property);
        }

        public IEnumerable<Product> GetProductsByManufacturer(Company manufacturer)
        {
            return cont.Product.ToList().FindAll(p => p.Manufacturer.Id == manufacturer.Id);
        }

        public IEnumerable<Product> GetProductsByManufacturer(Company manufacturer, IEnumerable<Product> products)
        {
            return products.ToList().FindAll(p => p.Manufacturer.Id == manufacturer.Id);
        }

        public Product AddProduct(string name, string property, string description, decimal cost, double volume, bool isIngr, bool isMerch, byte measure,
            string vendorCode, double cleanLoss, double fryLoss, double otherLosses, 
            double protains, double fats, double carbohydrates, double energyCalorie, double energyJoule,
            Category category, Company manufacturer)
        {
            Product p = new Product
            {
                Name = name,
                Property = property,
                Description = description,
                Cost = cost,
                FinalVolume = volume,
                IsExist = true,
                IsIngredient = isIngr,
                IsMerchandise = isMerch,
                Measure = (Measure)measure,
                VendorCode = vendorCode,
                LossDuringCleaning = cleanLoss,
                LossDuringFrying = fryLoss,
                OtherLosses = otherLosses,
                
                Energy =
                {
                    Protains = protains,
                    Fats = fats,
                    Carbohydrates = carbohydrates,
                    EnergyCalorie = energyCalorie,
                    EnergyJoule = energyJoule,
                },

                Category = category,
                Manufacturer = manufacturer,
            };
            cont.Product.Add(p);
            cont.SaveChanges();

            foreach (var b in cont.Branch.ToList())
                new WarehouseRepository(cont).AddWarehouse(DateTime.Now, 0, b, p);
            return p;
        }

        public Product AddProduct(Product product)
        {
            Product p = new Product
            {
                Name = product.Name,
                Property = product.Property,
                Description = product.Description,
                Cost = product.Cost,
                IsExist = true,
                IsIngredient = product.IsIngredient,
                IsMerchandise = product.IsMerchandise,
                Measure = product.Measure,
                VendorCode = product.VendorCode,
                LossDuringCleaning = product.LossDuringCleaning,
                LossDuringFrying = product.LossDuringFrying,
                OtherLosses = product.OtherLosses,

                Energy = product.Energy,

                Category = product.Category,
                Manufacturer = product.Manufacturer,
            };

            product.IsExist = false;

            foreach (var b in cont.Branch.ToList())
                new WarehouseRepository(cont).GetRecipesPrepIngsByProduct(product, new WarehouseRepository(cont).GetRecipesPrepIngsByBranch(b, null)).SingleOrDefault().Product = p;

            cont.Product.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Product AddIngredient(string name, string property, byte measure,
            string vendorCode, double cleanLoss, double fryLoss, double otherLosses,
            double protains, double fats, double carbohydrates, double energyCalorie, double energyJoule,
            Company manufacturer)
        {
            return AddProduct(name, property, null, 0, 0, true, false, measure, vendorCode, cleanLoss, fryLoss, otherLosses,
                protains, fats, carbohydrates, energyCalorie, energyJoule, null, manufacturer);
        }

        public Product AddMercandise(string name, string property, string description, decimal cost, double volume, byte measure,
            string vendorCode, double protains, double fats, double carbohydrates, double energyCalorie, double energyJoule,
            Category category, Company manufacturer)
        {
            return AddProduct(name, property, description, cost, volume, false, true, measure, vendorCode, 0, 0, 0,
                protains, fats, carbohydrates, energyCalorie, energyJoule, category, manufacturer);
        }

        public Product EditProduct(string vendorCode, string name, string property, string description, decimal cost, bool isIngr, bool isMerch, byte measure,
            double cleanLoss, double fryLoss, double otherLosses,
            double protains, double fats, double carbohydrates, double energyCalorie, double energyJoule,
            Category category, Company manufacturer)
        {
            Product p = cont.Product.SingleOrDefault(pr => pr.IsExist && pr.VendorCode == vendorCode);
            if (cont.RecipeDishIngr.ToList().Exists(r => r.Ingredient == p) ||
                cont.RecipePrepIngr.ToList().Exists(r => r.Ingredient == p) ||
                cont.CheckMerchandise.ToList().Exists(r => r.Product == p))
            {
                IEnumerable<RecipeDishIngr> rdi = cont.RecipeDishIngr.ToList().FindAll(r => r.Dish.IsExist && r.Ingredient.IsExist && r.Ingredient.VendorCode == vendorCode);
                IEnumerable<RecipePrepIngr> rpi = cont.RecipePrepIngr.ToList().FindAll(r => r.Prepack.IsExist && r.Ingredient.IsExist && r.Ingredient.VendorCode == vendorCode);
                IEnumerable<Warehouse> wh = cont.Warehouse.ToList().FindAll(r => r.Product.VendorCode == vendorCode);

                p = AddProduct(p);

                List<Dish> dishes = new List<Dish>(rdi.Select(r => r.Dish)).Distinct().ToList();
                foreach (Dish d in dishes)
                {
                    Dish dish = new DishRepository(cont).AddDish(d);
                    foreach (RecipeDishIngr rd in cont.RecipeDishIngr.ToList().FindAll(r => r.Dish.Id == d.Id))
                    {
                        new RecipeDishIngrRepository(cont).AddRecipeDishIngr(rd.Volume, rd.Description, p, dish);
                    }
                }

                List<Prepack> results = new List<Prepack>(rpi.Select(r => r.Prepack)).Distinct().ToList();
                foreach (Prepack res in results)
                {
                    Prepack result = new PrepackRepository(cont).AddPrepack(res);
                    foreach (RecipePrepIngr rd in cont.RecipePrepIngr.ToList().FindAll(r => r.Prepack.Id == res.Id))
                    {
                        new RecipePrepIngrRepository(cont).AddRecipePrepIngr(rd.Volume, rd.Description, p, result);
                    }
                }

                foreach (Warehouse res in wh)
                {
                    Warehouse result = new WarehouseRepository(cont).AddWarehouse(res.InspectionDate.Value, res.FactualNumber.Value, res.Branch, p);
                }
            }
            else
            {
                p = cont.Product.SingleOrDefault(pr => pr.IsExist && pr.VendorCode == vendorCode);
                p.Name = name;
                p.Property = property;
                p.Description = description;
                p.Cost = cost;
                p.IsExist = true;
                p.IsIngredient = isIngr;
                p.IsMerchandise = isMerch;
                p.Measure = (Measure)measure;
                p.VendorCode = vendorCode;
                p.LossDuringCleaning = cleanLoss;
                p.LossDuringFrying = fryLoss;
                p.OtherLosses = otherLosses;

                p.Energy = new EnergyValue
                {
                    Protains = protains,
                    Fats = fats,
                    Carbohydrates = carbohydrates,
                    EnergyCalorie = energyCalorie,
                    EnergyJoule = energyJoule,
                };

                p.Category = category;
                p.Manufacturer = manufacturer;
            }
            cont.SaveChanges();
            return p;
        }
    }
}