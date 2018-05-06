using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class CheckMerchandiseRepository
    {
        static ModelContainer cont = new ModelContainer();

        public CheckMerchandiseRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<CheckMerchandise> Checks()
        {
            return cont.CheckMerchandise.OrderBy(c => c.Id);
        }

        public CheckMerchandise GetCheckById(int id)
        {
            return cont.CheckMerchandise.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<CheckMerchandise> GetChecksByProduct(Product product, IEnumerable<CheckMerchandise> CheckMerchandises)
        {
            if (CheckMerchandises == null)
                CheckMerchandises = cont.CheckMerchandise.OrderBy(c => c.Id);
            return CheckMerchandises.ToList().FindAll(p => p.Product.Id == product.Id);
        }

        public IEnumerable<CheckMerchandise> GetChecksByOrder(Order order, IEnumerable<CheckMerchandise> CheckMerchandises)
        {
            if (CheckMerchandises == null)
                CheckMerchandises = cont.CheckMerchandise.OrderBy(c => c.Id);
            return CheckMerchandises.ToList().FindAll(p => p.Order.Id == order.Id);
        }

        public void DeleteCheck(int id)
        {
            cont.CheckMerchandise.Remove(cont.CheckMerchandise.Find(id));
            cont.SaveChanges();
        }

        public CheckMerchandise AddCheck(Product product, Order order)
        {
            CheckMerchandise p = new CheckMerchandise
            {
                IsPaid = false,
                AddDateTime = DateTime.Now,
                PaidDateTime = null,
                FinalPrice = null,
                Product = product,
                Order = order,
            };
            cont.CheckMerchandise.Add(p);
            cont.SaveChanges();
            return p;
        }

        public CheckMerchandise PaidCheck(int id)
        {
            CheckMerchandise p = cont.CheckMerchandise.SingleOrDefault(c => c.Id == id);

            p.IsPaid = true;
            p.FinalPrice = p.Product.Cost;
            p.PaidDateTime = DateTime.Now;

            cont.SaveChanges();
            return p;
        }

        public CheckMerchandise PaidCheck(int id, decimal finalPrice)
        {
            CheckMerchandise p = cont.CheckMerchandise.SingleOrDefault(c => c.Id == id);

            p.IsPaid = true;
            p.FinalPrice = finalPrice;
            p.PaidDateTime = DateTime.Now;

            cont.SaveChanges();
            return p;
        }
    }
}