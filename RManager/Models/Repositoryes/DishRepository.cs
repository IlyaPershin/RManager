using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class DishRepository
    {
        static ModelContainer cont = new ModelContainer();

        public DishRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<Dish> Dishes()
        {
            return cont.Dish.OrderBy(c => c.Id);
        }

        public Dish GetDishById(int id)
        {
            return cont.Dish.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Dish> GetDishesByName(string name)
        {
            return cont.Dish.ToList().FindAll(p => p.Name == name);
        }

        public IEnumerable<Dish> GetDishesByName(string name, IEnumerable<Dish> Dishs)
        {
            return Dishs.ToList().FindAll(p => p.Name == name);
        }

        public void DeleteDish(int id)
        {
            if (cont.RecipeDishPrep.ToList().Exists(o => o.Dish.Id == id) ||
                cont.RecipeDishIngr.ToList().Exists(o => o.Dish.Id == id) ||
                cont.CheckDish.ToList().Exists(o => o.Dish.Id == id))
            {
                cont.Dish.SingleOrDefault(p => p.Id == id).IsExist = false;
                return;
            }
            cont.Dish.Remove(cont.Dish.Find(id));
            cont.SaveChanges();
        }

        public Dish AddDish(string name, string description, decimal cost, double finalVolume, byte measure, 
            string vendorCode, DateTime start, DateTime end,
            double protains, double fats, double carbohydrates, double energyCalorie, double energyJoule,
            Room cookingPlace, Category category)
        {
            Dish p = new Dish
            {
                Name = name,
                Description = description,
                Cost = cost,
                FinalVolume = finalVolume,
                IsExist = true,
                Measure = (Measure)measure,
                VendorCode = vendorCode,
                CookStartTime = start,
                CookEndTime = end,

                Energy =
                {
                    Protains = protains,
                    Fats = fats,
                    Carbohydrates = carbohydrates,
                    EnergyCalorie = energyCalorie,
                    EnergyJoule = energyJoule,
                },

                CookingPlace = cookingPlace,
                Category = category,
            };
            cont.Dish.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Dish AddDish(Dish dish)
        {
            Dish p = new Dish
            {
                Name = dish.Name,
                Description = dish.Description,
                Cost = dish.Cost,
                FinalVolume = dish.FinalVolume,
                IsExist = dish.IsExist,
                Measure = dish.Measure,
                VendorCode = dish.VendorCode,
                CookStartTime = dish.CookStartTime,
                CookEndTime = dish.CookEndTime,

                Energy = dish.Energy,

                CookingPlace = dish.CookingPlace,
                Category = dish.Category,
            };

            dish.IsExist = false;

            cont.Dish.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Dish EditDish(string vendorCode, string name, string description, decimal cost, double finalVolume, byte measure,
            DateTime start, DateTime end,
            double protains, double fats, double carbohydrates, double energyCalorie, double energyJoule,
            Room cookingPlace, Category category)
        {
            Dish d = cont.Dish.SingleOrDefault(di => di.IsExist && di.VendorCode == vendorCode);
            if (cont.RecipeDishPrep.ToList().Exists(r => r.Dish.Id == d.Id) ||
                cont.RecipeDishIngr.ToList().Exists(r => r.Dish.Id == d.Id) ||
                cont.CheckDish.ToList().Exists(r => r.Dish.Id == d.Id))
            {
                IEnumerable<RecipeDishPrep> rdp = cont.RecipeDishPrep.ToList().FindAll(r => r.Dish.IsExist && r.Prepack.IsExist && r.Dish.VendorCode == vendorCode);
                IEnumerable<RecipeDishIngr> rdi = cont.RecipeDishIngr.ToList().FindAll(r => r.Ingredient.IsExist && r.Dish.IsExist && r.Dish.VendorCode == vendorCode);
                d = AddDish(d);
                
                foreach (RecipeDishPrep r in rdp)
                {
                    new RecipeDishPrepRepository(cont).AddRecipeDishPrep(r.Volume, r.Description, r.Prepack, d);
                }

                foreach (RecipeDishIngr r in rdi)
                {
                    new RecipeDishIngrRepository(cont).AddRecipeDishIngr(r.Volume, r.Description, r.Ingredient, d);
                }
            }
            else
            {
                d = cont.Dish.SingleOrDefault(c => c.VendorCode.Equals(vendorCode));
                d.Name = name;
                d.Description = description;
                d.Cost = cost;
                d.FinalVolume = finalVolume;
                d.IsExist = true;
                d.Measure = (Measure)measure;
                d.VendorCode = vendorCode;
                d.CookStartTime = start;
                d.CookEndTime = end;

                d.Energy = new EnergyValue
                {
                    Protains = protains,
                    Fats = fats,
                    Carbohydrates = carbohydrates,
                    EnergyCalorie = energyCalorie,
                    EnergyJoule = energyJoule,
                };

                d.CookingPlace = cookingPlace;
                d.Category = category;
            }
            cont.SaveChanges();
            return d;
        }
    }
}