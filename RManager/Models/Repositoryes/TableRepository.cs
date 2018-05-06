using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class TableRepository
    {
        static ModelContainer cont = new ModelContainer();

        public TableRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<Table> Tables()
        {
            return cont.Table.OrderBy(t => t.Id);
        }

        public Table GetTableById(int id)
        {
            return cont.Table.SingleOrDefault(t => t.Id == id);
        }

        public IEnumerable<Table> GetTablesByNumber(short number)
        {
            return cont.Table.ToList().FindAll(t => t.Number == number);
        }

        public IEnumerable<Table> GetExistedTableByNumber(short number)
        {
            return cont.Table.ToList().FindAll(t => t.IsExist && t.Number == number);
        }

        public IEnumerable<Table> GetTablesOfRoom(Room room)
        {
            return cont.Table.ToList().FindAll(t => t.Room == room);
        }

        public IEnumerable<Table> GetExistedTablesOfRoom(Room room)
        {
            return cont.Table.ToList().FindAll(t => t.IsExist && t.Room == room);
        }

        public void DeleteTable(int id)
        {
            if (cont.Order.ToList().Exists(o => o.Table.Id == id))
            {
                cont.Table.Find(id).IsExist = false;
                return;
            }
            cont.Table.Remove(cont.Table.Find(id));
            cont.SaveChanges();
        }

        public Table AddTable(short number, string description, Room room)
        {
            Table t = new Table
            {
                Number = number,
                Description = description,
                IsExist = true,
                Room = room,
            };
            cont.Table.Add(t);
            cont.SaveChanges();
            return t;
        }
    }
}