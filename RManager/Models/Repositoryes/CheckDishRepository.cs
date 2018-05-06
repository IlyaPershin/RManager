using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class CheckDishRepository
    {
        static ModelContainer cont = new ModelContainer();

        public CheckDishRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<CheckDish> Checks()
        {
            return cont.CheckDish.OrderBy(c => c.Id);
        }

        public CheckDish GetCheckById(int id)
        {
            return cont.CheckDish.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<CheckDish> GetChecksByDish(Dish dish, IEnumerable<CheckDish> CheckDishs)
        {
            if (CheckDishs == null)
                CheckDishs = cont.CheckDish.OrderBy(c => c.Id);
            return CheckDishs.ToList().FindAll(p => p.Dish.Id == dish.Id);
        }

        public IEnumerable<CheckDish> GetChecksByOrder(Order order, IEnumerable<CheckDish> CheckDishs)
        {
            if (CheckDishs == null)
                CheckDishs = cont.CheckDish.OrderBy(c => c.Id);
            return CheckDishs.ToList().FindAll(p => p.Order.Id == order.Id);
        }

        public void DeleteCheck(int id)
        {
            cont.CheckDish.Remove(cont.CheckDish.Single(c => c.Id == id));
            cont.SaveChanges();
        }

        public CheckDish AddCheck(Dish dish, Order order)
        {
            CheckDish p = new CheckDish
            {
                IsPaid = false,
                AddDateTime = DateTime.Now,
                PaidDateTime = null,
                FinalPrice = null,
                Dish = dish,
                Order = order,
            };
            cont.CheckDish.Add(p);
            cont.SaveChanges();
            return p;
        }

        public CheckDish PaidCheck(int id)
        {
            CheckDish p = cont.CheckDish.SingleOrDefault(c => c.Id == id);

            p.IsPaid = true;
            p.FinalPrice = p.Dish.Cost;
            p.PaidDateTime = DateTime.Now;

            cont.SaveChanges();
            return p;
        }

        public CheckDish PaidCheck(int id, decimal finalPrice)
        {
            CheckDish p = cont.CheckDish.SingleOrDefault(c => c.Id == id);

            p.IsPaid = true;
            p.FinalPrice = finalPrice;
            p.PaidDateTime = DateTime.Now;

            cont.SaveChanges();
            return p;
        }
    }
}