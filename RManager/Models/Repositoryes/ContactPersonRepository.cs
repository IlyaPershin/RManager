using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class ContactPersonRepository
    {
        static ModelContainer cont = new ModelContainer();

        public ContactPersonRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<ContactPerson> ContactPersons()
        {
            return (IEnumerable<ContactPerson>)cont.Person.ToList().FindAll(cp => cp.GetType().Equals(typeof(ContactPerson))).OrderBy(c => c.Id);
        }

        static public ContactPerson GetContactPersonById(int id)
        {
            return (ContactPerson)cont.Person.SingleOrDefault(c => c.Id == id);
        }

        static public ContactPerson GetContactPersonByName(string name)
        {
            return (ContactPerson)cont.Person.SingleOrDefault(p => p.Surname == name || p.FirstName == name);
        }

        static public ContactPerson GetContactPersonByPhone(string phone)
        {
            return (ContactPerson)cont.Person.SingleOrDefault(p => p.Phone == phone);
        }

        static public ContactPerson GetContactPersonByEmail(string email)
        {
            return (ContactPerson)cont.Person.SingleOrDefault(p => p.Email == email);
        }

        public void DeleteContactPerson(int id)
        {
            cont.Person.Remove(cont.Person.Find(id));
            cont.SaveChanges();
        }

        public ContactPerson AddContactPerson(string surname, string firstname, string middlename, string phone, string email,
            string country, string city, string street, string building, string index,
            Company company)
        {

            ContactPerson p = new ContactPerson
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
                Company = company
            };
            cont.Person.Add(p);
            cont.SaveChanges();
            return p;
        }

        public ContactPerson AddContactPerson(string surname, string firstname, string middlename, string phone, string email, 
            Adress adress, 
            Company company)
        {

            ContactPerson p = new ContactPerson
            {
                Surname = surname,
                FirstName = firstname,
                MiddleName = middlename,
                Phone = phone,
                Email = email,
                Adress = adress,
                Company = company
            };
            cont.Person.Add(p);
            cont.SaveChanges();
            return p;
        }

        public ContactPerson AddContactPerson(string surname, string firstname, string middlename, string phone, string email, 
            Company company)
        {

            ContactPerson p = new ContactPerson
            {
                Surname = surname,
                FirstName = firstname,
                MiddleName = middlename,
                Phone = phone,
                Email = email,
                Adress = null,
                Company = company
            };
            cont.Person.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Person EditPerson(int id, string surname, string firstname, string middlename, string phone, string email,
            string country, string city, string street, string building, string index, 
            Company company)
        {
            ContactPerson p = (ContactPerson)cont.Person.SingleOrDefault(ca => ca.Id == id);

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
            p.Company = company;
            cont.SaveChanges();
            return p;
        }

        public ContactPerson EditContactPerson(int id, string surname, string firstname, string middlename, string phone, string email, 
            Adress adress, 
            Company company)
        {
            ContactPerson p = (ContactPerson)cont.Person.SingleOrDefault(ca => ca.Id == id);

            p.Surname = surname;
            p.FirstName = firstname;
            p.MiddleName = middlename;
            p.Phone = phone;
            p.Email = email;
            p.Adress = adress;
            p.Company = company;
            cont.SaveChanges();
            return p;
        }

        public ContactPerson EditContactPerson(int id, string surname, string firstname, string middlename, string phone, string email, 
            Company company)
        {
            ContactPerson p = (ContactPerson)cont.Person.SingleOrDefault(ca => ca.Id == id);

            p.Surname = surname;
            p.FirstName = firstname;
            p.MiddleName = middlename;
            p.Phone = phone;
            p.Email = email;
            p.Adress = null;
            p.Company = company;
            cont.SaveChanges();
            return p;
        }
    }
}