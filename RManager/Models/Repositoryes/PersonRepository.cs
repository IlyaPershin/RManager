using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class PersonRepository
    {
        static ModelContainer cont = new ModelContainer();

        public PersonRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<Person> Persones()
        {
            return cont.Person.OrderBy(p => p.Id);
        }

        static public Person GetPersonById(int id)
        {
            return cont.Person.SingleOrDefault(p => p.Id == id);
        }

        static public Person GetPersonByName(string name)
        {
            return cont.Person.SingleOrDefault(p => p.Surname == name || p.FirstName == name);
        }

        static public Person GetPersonByPhone(string phone)
        {
            return cont.Person.SingleOrDefault(p => p.Phone == phone);
        }

        static public Person GetPersonByEmail(string email)
        {
            return cont.Person.SingleOrDefault(p => p.Email == email);
        }

        public void DeletePerson(int id)
        {
            cont.Person.Remove(cont.Person.Find(id));
            cont.SaveChanges();
        }

        public Person AddPerson(string surname, string firstname, string middlename, string phone, string email, 
            string country, string city, string street, string building, string index)
        {

            Person p = new Person
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
                }
            };
            cont.Person.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Person AddPerson(string surname, string firstname, string middlename, string phone, string email, Adress adress)
        {

            Person p = new Person
            {
                Surname = surname,
                FirstName = firstname,
                MiddleName = middlename,
                Phone = phone,
                Email = email,
                Adress = adress
            };
            cont.Person.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Person AddPerson(string surname, string firstname, string middlename, string phone, string email)
        {

            Person p = new Person
            {
                Surname = surname,
                FirstName = firstname,
                MiddleName = middlename,
                Phone = phone,
                Email = email,
                Adress = null
            };
            cont.Person.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Person EditPerson(int id, string surname, string firstname, string middlename, string phone, string email,
            string country, string city, string street, string building, string index)
        {
            Person p = cont.Person.SingleOrDefault(ca => ca.Id == id);

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
            cont.SaveChanges();
            return p;
        }

        public Person EditPerson(int id, string surname, string firstname, string middlename, string phone, string email, Adress adress)
        {
            Person p = cont.Person.SingleOrDefault(ca => ca.Id == id);

            p.Surname = surname;
            p.FirstName = firstname;
            p.MiddleName = middlename;
            p.Phone = phone;
            p.Email = email;
            p.Adress = adress;
            cont.SaveChanges();
            return p;
        }

        public Person EditPerson(int id, string surname, string firstname, string middlename, string phone, string email)
        {
            Person p = cont.Person.SingleOrDefault(ca => ca.Id == id);

            p.Surname = surname;
            p.FirstName = firstname;
            p.MiddleName = middlename;
            p.Phone = phone;
            p.Email = email;
            p.Adress = null;
            cont.SaveChanges();
            return p;
        }
    }
}