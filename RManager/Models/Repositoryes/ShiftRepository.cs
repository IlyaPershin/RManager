using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class ShiftRepository
    {
        static ModelContainer cont = new ModelContainer();

        public ShiftRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<Shift> Shifts()
        {
            return cont.Shift.OrderBy(b => b.Id);
        }

        static public Shift GetShiftById(int id)
        {
            return cont.Shift.SingleOrDefault(b => b.Id == id);
        }

        static public IEnumerable<Shift> GetShiftByDate(DateTime date)
        {
            return cont.Shift.ToList().FindAll(b => b.StartDateTime == date || b.EndDateTime == date);
        }

        static public IEnumerable<Shift> GetShiftForYear(DateTime date)
        {
            return cont.Shift.ToList().FindAll(b => b.StartDateTime.Year == date.Year || b.EndDateTime.Value.Year == date.Year);
        }

        static public IEnumerable<Shift> GetShiftForMonth(DateTime date)
        {
            return cont.Shift.ToList().FindAll(b => (b.StartDateTime.Year == date.Year && b.StartDateTime.Month == date.Month) ||
            ((b.EndDateTime.Value.Year == date.Year && b.EndDateTime.Value.Month == date.Month)));
        }

        static public IEnumerable<Shift> GetShiftForDay(DateTime date)
        {
            return cont.Shift.ToList().FindAll(b => (b.StartDateTime.Year == date.Year && b.StartDateTime.Month == date.Month && b.StartDateTime.Day == date.Day) ||
            (b.EndDateTime.Value.Year == date.Year && b.EndDateTime.Value.Month == date.Month && b.EndDateTime.Value.Day == date.Day));
        }

        public void DeleteShift(int id)
        {
            cont.Shift.Remove(cont.Shift.Find(id));
            cont.SaveChanges();
        }

        public Shift StartShift(Employee employee, Branch branch)
        {
            decimal? lastCash = (from shift in cont.Shift
                                 orderby shift.EndDateTime.Value
                                 select shift.EndFactualCash).Last();
            Shift s = new Shift
            {
                StartDateTime = DateTime.Now,
                StartFactualCashbox = lastCash.Value,
                Person = employee,
                Branch = branch,
            };

            cont.SaveChanges();
            return s;
        }

        public Shift EndShift(int id, decimal endCash, decimal endNonCash)
        {
            Shift s = cont.Shift.SingleOrDefault(ca => ca.Id == id);
            s.EndDateTime = DateTime.Now;
            s.EndFactualCash = endCash;
            s.EndFactualNonCash = endNonCash;

            cont.SaveChanges();
            return s;
        }

        public Shift EditShift(int id, decimal startCash, decimal endCash, decimal endNonCash, Employee employee, Branch branch)
        {
            Shift s = cont.Shift.SingleOrDefault(ca => ca.Id == id);

            s.StartFactualCashbox = startCash;
            s.EndFactualCash = endCash;
            s.EndFactualNonCash = endNonCash;
            s.Person = employee;
            s.Branch = branch;

            cont.SaveChanges();
            return s;
        }
    }
}