using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class PositionRepository
    {
        static ModelContainer cont = new ModelContainer();

        public PositionRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<Position> Positions()
        {
            return cont.Position.OrderBy(c => c.Id);
        }

        static public Position GetPosition(int id)
        {
            return cont.Position.SingleOrDefault(p => p.Id == id);
        }

        public void DeletePosition(int id)
        {
            cont.Position.Remove(cont.Position.Find(id));
            cont.SaveChanges();
        }

        public Position AddPosition(string name, bool orders, bool menu, bool warehouse, bool stuff, bool reports)
        {
            Position p = new Position
            {
                Name = name,
                WorkWithOrders = orders,
                WorkWithMenu = menu,
                WorkWithWarehouse = warehouse,
                WorkWithStuff = stuff,
                WorkWithReports = reports
            };
            cont.Position.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Position AddPosition(string name)
        {
            Position p = new Position
            {
                Name = name
            };
            cont.Position.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Position EditPosition(int id, string name, bool orders, bool menu, bool warehouse, bool stuff, bool reports)
        {
            Position p = cont.Position.SingleOrDefault(po => po.Id == id);
            p.Name = name;
            p.WorkWithOrders = orders;
            p.WorkWithMenu = menu;
            p.WorkWithWarehouse = warehouse;
            p.WorkWithStuff = stuff;
            p.WorkWithReports = reports;
            cont.SaveChanges();
            return p;
        }

        public Position AddWorkWithOrders(int id)
        {
            Position p = cont.Position.SingleOrDefault(po => po.Id == id);
            p.WorkWithOrders = true;
            cont.SaveChanges();
            return p;
        }

        public Position RemoveWorkWithOrders(int id)
        {
            Position p = cont.Position.SingleOrDefault(po => po.Id == id);
            p.WorkWithOrders = false;
            cont.SaveChanges();
            return p;
        }

        public Position AddWorkWithMenu(int id)
        {
            Position p = cont.Position.SingleOrDefault(po => po.Id == id);
            p.WorkWithMenu = true;
            cont.SaveChanges();
            return p;
        }

        public Position RemoveWorkWithMenu(int id)
        {
            Position p = cont.Position.SingleOrDefault(po => po.Id == id);
            p.WorkWithMenu = false;
            cont.SaveChanges();
            return p;
        }

        public Position AddWorkWithWarehouse(int id)
        {
            Position p = cont.Position.SingleOrDefault(po => po.Id == id);
            p.WorkWithWarehouse = true;
            cont.SaveChanges();
            return p;
        }

        public Position RemoveWorkWithWarehouse(int id)
        {
            Position p = cont.Position.SingleOrDefault(po => po.Id == id);
            p.WorkWithWarehouse = false;
            cont.SaveChanges();
            return p;
        }

        public Position AddWorkWithStuff(int id)
        {
            Position p = cont.Position.SingleOrDefault(po => po.Id == id);
            p.WorkWithStuff = true;
            cont.SaveChanges();
            return p;
        }

        public Position RemoveWorkWithStuff(int id)
        {
            Position p = cont.Position.SingleOrDefault(po => po.Id == id);
            p.WorkWithStuff = false;
            cont.SaveChanges();
            return p;
        }

        public Position AddWorkWithReports(int id)
        {
            Position p = cont.Position.SingleOrDefault(po => po.Id == id);
            p.WorkWithReports = true;
            cont.SaveChanges();
            return p;
        }

        public Position RemoveWorkWithReports(int id)
        {
            Position p = cont.Position.SingleOrDefault(po => po.Id == id);
            p.WorkWithReports = false;
            cont.SaveChanges();
            return p;
        }
    }
}