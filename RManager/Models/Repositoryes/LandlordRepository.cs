using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class LandlordRepository
    {
        static ModelContainer cont = new ModelContainer();

        public LandlordRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<Landlord> Landlords()
        {
            return (IEnumerable<Landlord>)cont.Person.ToList().FindAll(cp => cp.GetType().Equals(typeof(Landlord))).OrderBy(c => c.Id);
        }

        static public Landlord GetLandlordById(int id)
        {
            return (Landlord)cont.Person.SingleOrDefault(c => c.Id == id);
        }

        static public Landlord GetLandlordByName(string name)
        {
            return (Landlord)cont.Person.SingleOrDefault(p => p.Surname == name || p.FirstName == name);
        }

        static public Landlord GetLandlordByPhone(string phone)
        {
            return (Landlord)cont.Person.SingleOrDefault(p => p.Phone == phone);
        }

        static public Landlord GetLandlordByEmail(string email)
        {
            return (Landlord)cont.Person.SingleOrDefault(p => p.Email == email);
        }

        public void DeleteLandlord(int id)
        {
            cont.Person.Remove(cont.Person.Find(id));
            cont.SaveChanges();
        }

        public Landlord AddLandlord(string surname, string firstname, string middlename, string phone, string email,
            string country, string city, string street, string building, string index,
            string inn, string ogrn, string bankAccaunt)
        {

            Landlord p = new Landlord
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

                INN = inn,
                OGRN = ogrn,
                BankAccount = bankAccaunt,
            };
            cont.Person.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Landlord AddLandlord(string surname, string firstname, string middlename, string phone, string email,
            Adress adress,
            string inn, string ogrn, string bankAccaunt)
        {

            Landlord p = new Landlord
            {
                Surname = surname,
                FirstName = firstname,
                MiddleName = middlename,
                Phone = phone,
                Email = email,

                Adress = adress,

                INN = inn,
                OGRN = ogrn,
                BankAccount = bankAccaunt,
            };
            cont.Person.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Landlord AddLandlord(string surname, string firstname, string middlename, string phone, string email,
            string inn, string ogrn, string bankAccaunt)
        {

            Landlord p = new Landlord
            {
                Surname = surname,
                FirstName = firstname,
                MiddleName = middlename,
                Phone = phone,
                Email = email,

                Adress = null,

                INN = inn,
                OGRN = ogrn,
                BankAccount = bankAccaunt,
            };
            cont.Person.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Person EditPerson(int id, string surname, string firstname, string middlename, string phone, string email,
            string country, string city, string street, string building, string index,
            string inn, string ogrn, string bankAccaunt)
        {
            Landlord p = (Landlord)cont.Person.SingleOrDefault(ca => ca.Id == id);

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

            p.INN = inn;
            p.OGRN = ogrn;
            p.BankAccount = bankAccaunt;

            cont.SaveChanges();
            return p;
        }

        public Landlord EditLandlord(int id, string surname, string firstname, string middlename, string phone, string email,
            Adress adress,
            string inn, string ogrn, string bankAccaunt)
        {
            Landlord p = (Landlord)cont.Person.SingleOrDefault(ca => ca.Id == id);

            p.Surname = surname;
            p.FirstName = firstname;
            p.MiddleName = middlename;
            p.Phone = phone;
            p.Email = email;

            p.Adress = adress;

            p.INN = inn;
            p.OGRN = ogrn;
            p.BankAccount = bankAccaunt;

            cont.SaveChanges();
            return p;
        }

        public Landlord EditLandlord(int id, string surname, string firstname, string middlename, string phone, string email,
            string inn, string ogrn, string bankAccaunt)
        {
            Landlord p = (Landlord)cont.Person.SingleOrDefault(ca => ca.Id == id);

            p.Surname = surname;
            p.FirstName = firstname;
            p.MiddleName = middlename;
            p.Phone = phone;
            p.Email = email;

            p.Adress = null;

            p.INN = inn;
            p.OGRN = ogrn;
            p.BankAccount = bankAccaunt;

            cont.SaveChanges();
            return p;
        }
    }
}