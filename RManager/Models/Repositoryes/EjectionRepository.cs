using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class EjectionRepository
    {
        static ModelContainer cont = new ModelContainer();

        public EjectionRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<Ejection> Ejections()
        {
            return cont.Ejection.OrderBy(b => b.Id);
        }

        static public Ejection GetEjectionById(int id)
        {
            return cont.Ejection.SingleOrDefault(b => b.Id == id);
        }

        static public IEnumerable<Ejection> GetEjectionsByCulprit(Employee culprit)
        {
            return cont.Ejection.ToList().FindAll(b => b.Culprit.Id == culprit.Id);
        }

        static public IEnumerable<Ejection> GetEjectionsByProduct(Product product)
        {
            return cont.Ejection.ToList().FindAll(b => b.Warehouse.Product.Id == product.Id);
        }

        static public IEnumerable<Ejection> GetEjectionByDate(DateTime date)
        {
            return cont.Ejection.ToList().FindAll(b => b.Date == date);
        }

        static public IEnumerable<Ejection> GetEjectionForYear(DateTime date)
        {
            return cont.Ejection.ToList().FindAll(b => b.Date.Year == date.Year);
        }

        static public IEnumerable<Ejection> GetEjectionForMonth(DateTime date)
        {
            return cont.Ejection.ToList().FindAll(b => b.Date.Year == date.Year && b.Date.Month == date.Month);
        }

        static public IEnumerable<Ejection> GetEjectionForDay(DateTime date)
        {
            return cont.Ejection.ToList().FindAll(b => b.Date.Year == date.Year && b.Date.Month == date.Month && b.Date.Day == date.Day);
        }

        public void DeleteEjection(int id)
        {
            cont.Ejection.Remove(cont.Ejection.Find(id));
            cont.SaveChanges();
        }

        public Ejection AddEjection(double volume, Employee culprit, Warehouse warehouse)
        {
            Ejection p = new Ejection
            {
                Date = DateTime.Now,
                Volume = volume,
                Culprit = culprit,
                Warehouse = warehouse,
            };
            cont.Ejection.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Ejection AddEjection(DateTime date, double volume, Employee culprit, Warehouse warehouse)
        {
            Ejection p = new Ejection
            {
                Date = DateTime.Now,
                Volume = volume,
                Culprit = culprit,
                Warehouse = warehouse,
            };
            cont.Ejection.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Ejection EditEjection(int id, DateTime date, double volume, Employee culprit, Warehouse warehouse)
        {
            Ejection p = cont.Ejection.SingleOrDefault(ca => ca.Id == id);

            p.Date = date;
            p.Volume = volume;
            p.Culprit = culprit;
            p.Warehouse = warehouse;

            cont.SaveChanges();
            return p;
        }
    }
}