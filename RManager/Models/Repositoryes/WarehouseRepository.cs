using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class WarehouseRepository
    {
        static ModelContainer cont = new ModelContainer();

        public WarehouseRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<Warehouse> Warehouses()
        {
            return cont.Warehouse.OrderBy(c => c.Id);
        }

        public Warehouse GetRecipeDishIngrById(int id)
        {
            return cont.Warehouse.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Warehouse> GetRecipesPrepIngsByProduct(Product product, IEnumerable<Warehouse> Warehouse)
        {
            if (Warehouse == null)
                Warehouse = Warehouses();
            return Warehouse.ToList().FindAll(p => p.Product.Id == product.Id);
        }

        public IEnumerable<Warehouse> GetRecipesPrepIngsByBranch(Branch branch, IEnumerable<Warehouse> Warehouse)
        {
            if (Warehouse == null)
                Warehouse = Warehouses();
            return Warehouse.ToList().FindAll(p => p.Branch.Id == branch.Id);
        }

        public void DeleteWarehouse(int id)
        {
            cont.Warehouse.Remove(cont.Warehouse.Find(id));
            cont.SaveChanges();
        }

        public Warehouse AddWarehouse(DateTime date, double factualNumber, Branch branch, Product ingredient)
        {
            Warehouse p = new Warehouse
            {
                InspectionDate = date,
                FactualNumber = factualNumber,
                Branch = branch, 
                Product = ingredient,
            };
            cont.Warehouse.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Warehouse AddInspection(int id, double factualNumber)
        {
            Warehouse p = GetRecipeDishIngrById(id);
            p.InspectionDate = DateTime.Now;
            p.FactualNumber = factualNumber;
            cont.SaveChanges();
            return p;
        }

        public Warehouse EditWarehouse(int id, DateTime date, double factualNumber, Branch branch, Product ingredient)
        {
            Warehouse p = GetRecipeDishIngrById(id);
            p.InspectionDate = date;
            p.FactualNumber = factualNumber;
            p.Branch = branch;
            p.Product = ingredient;
            cont.SaveChanges();
            return p;
        }
    }
}