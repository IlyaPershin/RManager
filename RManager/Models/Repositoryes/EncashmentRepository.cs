using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class EncashmentRepository
    {
        static ModelContainer cont = new ModelContainer();

        public EncashmentRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<Encashment> Encashments()
        {
            return cont.Encashment.OrderBy(b => b.Id);
        }

        static public Encashment GetEncashmentById(int id)
        {
            return cont.Encashment.SingleOrDefault(b => b.Id == id);
        }

        static public IEnumerable<Encashment> GetEncashmentByDate(DateTime date)
        {
            return cont.Encashment.ToList().FindAll(b => b.Date == date);
        }

        static public IEnumerable<Encashment> GetEncashmentForYear(DateTime date)
        {
            return cont.Encashment.ToList().FindAll(b => b.Date.Year == date.Year);
        }

        static public IEnumerable<Encashment> GetEncashmentForMonth(DateTime date)
        {
            return cont.Encashment.ToList().FindAll(b => b.Date.Year == date.Year && b.Date.Month == date.Month);
        }

        static public IEnumerable<Encashment> GetEncashmentForDay(DateTime date)
        {
            return cont.Encashment.ToList().FindAll(b => b.Date.Year == date.Year && b.Date.Month == date.Month && b.Date.Day == date.Day);
        }

        public void DeleteEncashment(int id)
        {
            cont.Encashment.Remove(cont.Encashment.Find(id));
            cont.SaveChanges();
        }

        public Encashment AddEncashment(decimal writeOff, Branch branch)
        {
            Encashment p = new Encashment
            {
                Date = DateTime.Now,
                WriteOff = writeOff,
                Branch = branch,
            };
            cont.Encashment.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Encashment EditEncashment(int id, decimal writeOff)
        {
            Encashment p = cont.Encashment.SingleOrDefault(ca => ca.Id == id);

            p.WriteOff = writeOff;

            cont.SaveChanges();
            return p;
        }
    }
}