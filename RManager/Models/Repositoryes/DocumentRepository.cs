using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class DocumentRepository
    {
        static ModelContainer cont = new ModelContainer();

        public DocumentRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<Document> Documents()
        {
            return cont.Document.OrderBy(d => d.Id);
        }

        static public Document GetDocumentById(int id)
        {
            return cont.Document.SingleOrDefault(d => d.Id == id);
        }

        static public IEnumerable<Document> GetDocumentsByName(string name)
        {
            return cont.Document.ToList().FindAll(d => d.Name == name);
        }

        static public IEnumerable<Document> GetDocumentsBySerial(string serial)
        {
            return cont.Document.ToList().FindAll(d => d.Serial == serial);
        }

        static public IEnumerable<Document> GetDocumentsByNumber(string number)
        {
            return cont.Document.ToList().FindAll(d => d.Number == number);
        }

        static public Document GetDocumentByRegistration(string registration)
        {
            return cont.Document.SingleOrDefault(d => d.Registration == registration);
        }

        static public Document GetDocumentByPerson(Person person)
        {
            return cont.Document.SingleOrDefault(d => d.Exist && d.Man.Id == person.Id);
        }

        public void DeleteDocument(int id)
        {
            cont.Document.Remove(cont.Document.Find(id));
            cont.SaveChanges();
        }

        public Document AddDocument(string name, string serial, string number, string registration, Person person)
        {
            Document d = new Document
            {
                Name = name,
                Serial = serial,
                Number = number,
                Registration = registration,
                Exist = true,
                Man = person,
            };
            cont.Document.Add(d);
            cont.SaveChanges();
            return d;
        }

        public Document EditDocument(string newName, string newSerial, string newNumber, string newRegistration, Person person)
        {
            cont.Document.SingleOrDefault(doc => doc.Exist && doc.Man.Id == person.Id).Exist = false;
            Document d = new Document
            {
                Name = newName,
                Serial = newSerial,
                Number = newNumber,
                Registration = newRegistration,
                Exist = true,
                Man = person,
            };
            cont.Document.Add(d);
            cont.SaveChanges();
            return d;
        }
    }
}