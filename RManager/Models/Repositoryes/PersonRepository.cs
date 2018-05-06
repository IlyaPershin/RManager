using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace RManager.Models.Repositoryes
{
    public class PersonRepository : ApiController
    {
        static ModelContainer cont = new ModelContainer();

        public PersonRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        [Route("api/Person/GetAll")]
        public IEnumerable<Person> Persones()
        {
            return cont.Person.OrderBy(p => p.Id);
        }

        [Route("api/Person/GetById")]
        static public Person GetPersonById(int id)
        {
            return cont.Person.SingleOrDefault(p => p.Id == id);
        }

        [Route("api/Person/GetByName")]
        static public Person GetPersonByName(string name)
        {
            return cont.Person.SingleOrDefault(p => p.Surname == name || p.FirstName == name);
        }

        [Route("api/Person/GetByPhone")]
        static public Person GetPersonByPhone(string phone)
        {
            return cont.Person.SingleOrDefault(p => p.Phone == phone);
        }

        [Route("api/Person/GetByEmail")]
        static public Person GetPersonByEmail(string email)
        {
            return cont.Person.SingleOrDefault(p => p.Email == email);
        }

        [Route("api/Person/Delete")]
        public void DeletePerson(int id)
        {
            cont.Document.RemoveRange(cont.Document.ToList().FindAll(d => d.Man.Id == id));
            cont.Person.Remove(cont.Person.Find(id));
            cont.SaveChanges();
        }

        [Route("api/Person/AddFull")]
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

        [Route("api/Person/Add")]
        public Person AddPerson([FromBody]Person person)
        {

            Person p = new Person
            {
                Surname = person.Surname,
                FirstName = person.FirstName,
                MiddleName = person.MiddleName,
                Phone = person.Phone,
                Email = person.Email,
                Adress = person.Adress
            };
            cont.Person.Add(p);
            cont.SaveChanges();
            return p;
        }

        [Route("api/Person/EditFull")]
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

        [Route("api/Person/Edit")]
        public Person EditPerson(int id, [FromBody]Person person)
        {
            Person p = cont.Person.SingleOrDefault(ca => ca.Id == id);

            p.Surname = person.Surname;
            p.FirstName = person.FirstName;
            p.MiddleName = person.MiddleName;
            p.Phone = person.Phone;
            p.Email = person.Email;
            p.Adress = person.Adress;
            cont.SaveChanges();
            return p;
        }
    }
}