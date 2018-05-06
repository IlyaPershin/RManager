using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class CompanyOwnerRepository
    {
        static ModelContainer cont = new ModelContainer();

        public CompanyOwnerRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<CompanyOwner> CompanyOwners()
        {
            return (IEnumerable<CompanyOwner>)cont.Person.ToList().FindAll(cp => cp.GetType().Equals(typeof(CompanyOwner))).OrderBy(c => c.Id);
        }

        static public CompanyOwner GetCompanyOwnerById(int id)
        {
            return (CompanyOwner)cont.Person.SingleOrDefault(c => c.Id == id);
        }

        static public CompanyOwner GetCompanyOwnerByName(string name)
        {
            return (CompanyOwner)cont.Person.SingleOrDefault(p => p.Surname == name || p.FirstName == name);
        }

        static public CompanyOwner GetCompanyOwnerByPhone(string phone)
        {
            return (CompanyOwner)cont.Person.SingleOrDefault(p => p.Phone == phone);
        }

        static public CompanyOwner GetCompanyOwnerByEmail(string email)
        {
            return (CompanyOwner)cont.Person.SingleOrDefault(p => p.Email == email);
        }

        public void DeleteCompanyOwner(int id)
        {
            cont.Person.Remove(cont.Person.Find(id));
            cont.SaveChanges();
        }

        public CompanyOwner AddCompanyOwner(string surname, string firstname, string middlename, string phone, string email,
            string country, string city, string street, string building, string index,
            string login, string password, string description,
            string inn, string ogrn, Position position)
        {

            CompanyOwner p = new CompanyOwner
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
                Password = password,
                IsWorking = true,
                Description = description,

                Branch = null,

                INN = inn,
                OGRN = ogrn,
                Position = position,
            };
            cont.Person.Add(p);
            cont.SaveChanges();
            return p;
        }

        public CompanyOwner AddCompanyOwner(string surname, string firstname, string middlename, string phone, string email,
            Adress adress,
            string login, string password, string description,
            string inn, string ogrn, Position position)
        {

            CompanyOwner p = new CompanyOwner
            {
                Surname = surname,
                FirstName = firstname,
                MiddleName = middlename,
                Phone = phone,
                Email = email,

                Adress = adress,

                Login = login,
                Password = password,
                IsWorking = true,
                Description = description,

                Branch = null,

                INN = inn,
                OGRN = ogrn,
                Position = position,
            };
            cont.Person.Add(p);
            cont.SaveChanges();
            return p;
        }

        public CompanyOwner AddCompanyOwner(string surname, string firstname, string middlename, string phone, string email,
            string login, string password, string description,
            string inn, string ogrn, Position position)
        {

            CompanyOwner p = new CompanyOwner
            {
                Surname = surname,
                FirstName = firstname,
                MiddleName = middlename,
                Phone = phone,
                Email = email,

                Adress = new Adress
                {
                    Country = "",
                    City = "",
                    Street = "",
                    Bilding = "",
                    Index = "",
                },

                Login = login,
                Password = password,
                IsWorking = true,
                Description = description,

                Branch = null,

                INN = inn,
                OGRN = ogrn,
                Position = position,
            };
            cont.Person.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Person EditPerson(int id, string surname, string firstname, string middlename, string phone, string email,
            string country, string city, string street, string building, string index,
            string login, string password, bool isWorking, string description,
            string inn, string ogrn)
        {
            CompanyOwner p = (CompanyOwner)cont.Person.SingleOrDefault(ca => ca.Id == id);

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
            p.IsWorking = isWorking;
            p.Description = description;

            p.INN = inn;
            p.OGRN = ogrn;

            cont.SaveChanges();
            return p;
        }

        public CompanyOwner EditCompanyOwner(int id, string surname, string firstname, string middlename, string phone, string email,
            Adress adress,
            string login, string password, bool isWorking, string description,
            string inn, string ogrn)
        {
            CompanyOwner p = (CompanyOwner)cont.Person.SingleOrDefault(ca => ca.Id == id);

            p.Surname = surname;
            p.FirstName = firstname;
            p.MiddleName = middlename;
            p.Phone = phone;
            p.Email = email;

            p.Adress = adress;

            p.Login = login;
            p.Password = password;
            p.IsWorking = isWorking;
            p.Description = description;

            p.INN = inn;
            p.OGRN = ogrn;

            cont.SaveChanges();
            return p;
        }

        public CompanyOwner EditCompanyOwner(int id, string surname, string firstname, string middlename, string phone, string email,
            string login, string password, bool isWorking, string description,
            string inn, string ogrn)
        {
            CompanyOwner p = (CompanyOwner)cont.Person.SingleOrDefault(ca => ca.Id == id);

            p.Surname = surname;
            p.FirstName = firstname;
            p.MiddleName = middlename;
            p.Phone = phone;
            p.Email = email;

            p.Adress = null;

            p.Login = login;
            p.Password = password;
            p.IsWorking = isWorking;
            p.Description = description;

            p.INN = inn;
            p.OGRN = ogrn;

            cont.SaveChanges();
            return p;
        }
    }
}