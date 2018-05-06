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

        public Position GetPosition(int id)
        {
            return cont.Position.SingleOrDefault(p => p.Id == id);
        }

        public void DeletePosition(int id)
        {
            cont.Position.Remove(cont.Position.Find(id));
            cont.SaveChanges();
        }

        public Position AddPosition(string name, bool orders, bool menu, bool warehouse, bool stuff, bool reports, bool tables)
        {
            Position p = new Position
            {
                Name = name,
                WorkWithOrders = orders,
                WorkWithMenu = menu,
                WorkWithWarehouse = warehouse,
                WorkWithStuff = stuff,
                WorkWithReports = reports,
                WorkWithTables = tables
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

        public Position EditPosition(int id, string name, bool orders, bool menu, bool warehouse, bool stuff, bool reports, bool tables)
        {
            Position p = cont.Position.SingleOrDefault(po => po.Id == id);
            p.Name = name;
            p.WorkWithOrders = orders;
            p.WorkWithMenu = menu;
            p.WorkWithWarehouse = warehouse;
            p.WorkWithStuff = stuff;
            p.WorkWithReports = reports;
            p.WorkWithTables = tables;
            cont.SaveChanges();
            return p;
        }
        
        public Position GetPositionByName(string name)
        {
            return cont.Position.SingleOrDefault(po => po.Name == name);
        }

        public IEnumerable<Position> GetPositionByPowers(bool orders, bool menu, bool warehouse, bool stuff, bool reports, bool tables)
        {
            return cont.Position.ToList().FindAll(po => po.WorkWithOrders == orders && po.WorkWithMenu == menu && po.WorkWithWarehouse == warehouse &&
            po.WorkWithStuff == stuff && po.WorkWithReports == reports && po.WorkWithTables == tables);
        }
    }
}