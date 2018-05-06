using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class PurchaseRepository
    {
        static ModelContainer cont = new ModelContainer();

        public PurchaseRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<Purchase> Purchases()
        {
            return cont.Purchase.OrderBy(b => b.Id);
        }

        static public Purchase GetPurchaseById(int id)
        {
            return cont.Purchase.SingleOrDefault(b => b.Id == id);
        }

        static public IEnumerable<Purchase> GetPurchasesByProduct(Product product)
        {
            return cont.Purchase.ToList().FindAll(b => b.Warehouse.Product == product);
        }

        static public IEnumerable<Purchase> GetPurchasesByCompany(Company company)
        {
            return cont.Purchase.ToList().FindAll(b => b.Provider == company);
        }

        static public IEnumerable<Purchase> GetPurchaseByDate(DateTime date)
        {
            return cont.Purchase.ToList().FindAll(b => b.Date == date);
        }

        static public IEnumerable<Purchase> GetPurchaseForYear(DateTime date)
        {
            return cont.Purchase.ToList().FindAll(b => b.Date.Year == date.Year);
        }

        static public IEnumerable<Purchase> GetPurchaseForMonth(DateTime date)
        {
            return cont.Purchase.ToList().FindAll(b => b.Date.Year == date.Year && b.Date.Month == date.Month);
        }

        static public IEnumerable<Purchase> GetPurchaseForDay(DateTime date)
        {
            return cont.Purchase.ToList().FindAll(b => b.Date.Year == date.Year && b.Date.Month == date.Month && b.Date.Day == date.Day);
        }

        public void DeletePurchase(int id)
        {
            cont.Purchase.Remove(cont.Purchase.Find(id));
            cont.SaveChanges();
        }

        public Purchase AddPurchase(decimal price, double volume, Warehouse warehouse, Company provider)
        {
            Purchase p = new Purchase
            {
                Date = DateTime.Now,
                Price = price,
                Volume = volume,
                Warehouse = warehouse,
                Provider = provider,
            };
            cont.Purchase.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Purchase AddPurchase(DateTime date, decimal price, double volume, Warehouse warehouse, Company provider)
        {
            Purchase p = new Purchase
            {
                Date = date,
                Price = price,
                Volume = volume,
                Warehouse = warehouse,
                Provider = provider,
            };
            cont.Purchase.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Purchase EditPurchase(int id, DateTime date, decimal price, double volume, Warehouse warehouse, Company provider)
        {
            Purchase p = cont.Purchase.SingleOrDefault(ca => ca.Id == id);

            p.Date = date;
            p.Price = price;
            p.Volume = volume;
            p.Warehouse = warehouse;
            p.Provider = provider;

            cont.SaveChanges();
            return p;
        }
    }
}