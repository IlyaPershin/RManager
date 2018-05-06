using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class OrderRepository
    {
        static ModelContainer cont = new ModelContainer();

        public OrderRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<Order> Orders()
        {
            return cont.Order.OrderBy(b => b.Id);
        }

        public Order GetOrderById(int id)
        {
            return cont.Order.SingleOrDefault(b => b.Id == id);
        }

        public IEnumerable<Order> GetOrdersToYear(DateTime date)
        {
            return cont.Order.ToList().FindAll(b => b.DateOfOrder.Year == date.Year);
        }

        public IEnumerable<Order> GetOrdersToMonth(DateTime date)
        {
            return cont.Order.ToList().FindAll(b => b.DateOfOrder.Year == date.Year && b.DateOfOrder.Month == date.Month);
        }

        public IEnumerable<Order> GetOrdersToDay(DateTime date)
        {
            return cont.Order.ToList().FindAll(b => b.DateOfOrder.Year == date.Year && b.DateOfOrder.Month == date.Month && b.DateOfOrder.Day == date.Day);
        }

        public IEnumerable<Order> GetOrdersOfEmployee(Employee employee)
        {
            return cont.Order.ToList().FindAll(p => p.Employee == employee);
        }

        public IEnumerable<Order> GetOrdersOfTable(Table table)
        {
            return cont.Order.ToList().FindAll(p => p.Table == table);
        }

        public IEnumerable<Order> GetOrdersOfClient(Client client)
        {
            return cont.Order.ToList().FindAll(p => p.Client == client);
        }

        public Order AddOrder(int employee, int table, int client)
        {

            Order p = new Order
            {
                FinalPrice = 0,
                DateOfOrder = DateTime.Now,
                IsOpen = true,
                Employee = (Employee)cont.Person.Single(pers => pers.Id == employee),
                Table = cont.Table.Single(t => t.Id == table),
                Client = (Client)cont.Person.Single(c => c.Id == client),
                //Employee = employee,
                //Table = table,
                //Client = client,
            };
            cont.Order.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Order CloseOrder(int id, decimal finalPrice)
        {

            Order p = cont.Order.SingleOrDefault(or => or.Id == id);
            p.FinalPrice = finalPrice;
            p.IsOpen = false;
            p.DateOfOrder = DateTime.Now;
            cont.SaveChanges();
            return p;
        }

        public void DeleteOrder(int id)
        {
            Order p = cont.Order.SingleOrDefault(or => or.Id == id);

            var cdr = new CheckDishRepository(cont);
            bool isPaid = false;
            decimal totalCost = 0;
            foreach (var c in cdr.Checks().Where(c1 => c1.Order.Id == id))
            {
                if (c.IsPaid)
                {
                    isPaid = true;
                    totalCost += c.FinalPrice.Value;
                }
                else cdr.DeleteCheck(c.Id);
            }

            var cmr = new CheckMerchandiseRepository(cont);
            foreach (var c in cmr.Checks().Where(c1 => c1.Order.Id == id))
            {
                if (c.IsPaid)
                {
                    isPaid = true;
                    totalCost += c.FinalPrice.Value;
                }
                else cmr.DeleteCheck(c.Id);
            }

            if (!isPaid) cont.Order.Remove(p);
            else CloseOrder(id, totalCost);
            cont.SaveChanges();
        }

        public Order EditOrder(int id, decimal finalPrice, Employee employee, Table table, Client client)
        {
            Order p = cont.Order.SingleOrDefault(or => or.Id == id);
            p.FinalPrice = finalPrice;
            if (employee != null) p.Employee = employee;
            if (table != null) p.Table = table;
            if (client != null) p.Client = client;

            cont.SaveChanges();
            return p;
        }
    }
}