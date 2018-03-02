using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class ClientRepository
    {
        static ModelContainer cont = new ModelContainer();

        public ClientRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<Client> Clients()
        {
            return (IEnumerable<Client>)cont.Person.ToList().FindAll(cp => cp.GetType().Equals(typeof(Client))).OrderBy(c => c.Id);
        }

        static public Client GetClientById(int id)
        {
            return (Client)cont.Person.SingleOrDefault(c => c.Id == id);
        }

        static public Client GetClientByName(string name)
        {
            return (Client)cont.Person.SingleOrDefault(p => p.Surname == name || p.FirstName == name);
        }

        static public Client GetClientByPhone(string phone)
        {
            return (Client)cont.Person.SingleOrDefault(p => p.Phone == phone);
        }

        static public Client GetClientByEmail(string email)
        {
            return (Client)cont.Person.SingleOrDefault(p => p.Email == email);
        }

        public void DeleteClient(int id)
        {
            cont.Person.Remove(cont.Person.Find(id));
            cont.SaveChanges();
        }

        public Client AddClient(string surname, string firstname, string middlename, string phone, string email,
            string country, string city, string street, string building, string index,
            string login, string password)
        {

            Client p = new Client
            {
                Surname = surname,
                FirstName = firstname,
                MiddleName = middlename,
                Phone = phone,
                Email = email,
                Adress =
                {
                    Country = country,
                    City = city,
                    Street = street,
                    Bilding = building,
                    Index = index
                },
                Login = login,
                Password = password
            };
            cont.Person.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Client AddClient(string surname, string firstname, string middlename, string phone, string email,
            Adress adress,
            string login, string password)
        {

            Client p = new Client
            {
                Surname = surname,
                FirstName = firstname,
                MiddleName = middlename,
                Phone = phone,
                Email = email,
                Adress = adress,
                Login = login,
                Password = password
            };
            cont.Person.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Client AddClient(string surname, string firstname, string middlename, string phone, string email,
            string login, string password)
        {

            Client p = new Client
            {
                Surname = surname,
                FirstName = firstname,
                MiddleName = middlename,
                Phone = phone,
                Email = email,
                Adress = null,
                Login = login,
                Password = password
            };
            cont.Person.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Person EditPerson(int id, string surname, string firstname, string middlename, string phone, string email,
            string country, string city, string street, string building, string index,
            string login, string password)
        {
            Client p = (Client)cont.Person.SingleOrDefault(ca => ca.Id == id);

            p.Surname = surname;
            p.FirstName = firstname;
            p.MiddleName = middlename;
            p.Phone = phone;
            p.Email = email;
            p.Adress = new Adress
            {
                Country = country,
                City = city,
                Street = street,
                Bilding = building,
                Index = index
            };
            p.Login = login;
            p.Password = password;
            cont.SaveChanges();
            return p;
        }

        public Client EditClient(int id, string surname, string firstname, string middlename, string phone, string email,
            Adress adress,
            string login, string password)
        {
            Client p = (Client)cont.Person.SingleOrDefault(ca => ca.Id == id);

            p.Surname = surname;
            p.FirstName = firstname;
            p.MiddleName = middlename;
            p.Phone = phone;
            p.Email = email;
            p.Adress = adress;
            p.Login = login;
            p.Password = password;
            cont.SaveChanges();
            return p;
        }

        public Client EditClient(int id, string surname, string firstname, string middlename, string phone, string email,
            string login, string password)
        {
            Client p = (Client)cont.Person.SingleOrDefault(ca => ca.Id == id);

            p.Surname = surname;
            p.FirstName = firstname;
            p.MiddleName = middlename;
            p.Phone = phone;
            p.Email = email;
            p.Adress = null;
            p.Login = login;
            p.Password = password;
            cont.SaveChanges();
            return p;
        }
    }
}