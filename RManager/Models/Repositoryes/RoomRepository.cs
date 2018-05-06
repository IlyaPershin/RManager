using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class RoomRepository
    {
        static ModelContainer cont = new ModelContainer();

        public RoomRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<Room> Rooms()
        {
            return cont.Room.OrderBy(b => b.Id);
        }

        public Room GetRoomById(int id)
        {
            return cont.Room.SingleOrDefault(b => b.Id == id);
        }

        public Room GetRoomByName(string name)
        {
            return cont.Room.SingleOrDefault(b => b.Name == name);
        }

        public IEnumerable<Room> GetRoomsOfBranch(Branch branch)
        {
            return cont.Room.ToList().FindAll(p => p.Branch == branch);
        }

        public IEnumerable<Room> GetRoomsOfBranch(int branchId)
        {
            return cont.Room.ToList().FindAll(p => p.Branch.Id == branchId);
        }

        public void DeleteRoom(int id)
        {
            cont.Room.Remove(cont.Room.Find(id));
            cont.SaveChanges();
        }

        public Room AddRoom(string name, Branch branch)
        {

            Room p = new Room
            {
                Name = name,
                Branch = branch,
            };
            cont.Room.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Room EditRoom(int id, string name)
        {
            Room p = cont.Room.SingleOrDefault(ca => ca.Id == id);

            p.Name = name;

            cont.SaveChanges();
            return p;
        }

        public Room EditRoom(int id, string name, Branch branch)
        {
            Room p = cont.Room.SingleOrDefault(ca => ca.Id == id);

            p.Name = name;
            p.Branch = branch;

            cont.SaveChanges();
            return p;
        }
    }
}