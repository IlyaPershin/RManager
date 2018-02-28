using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class CompanyRepository
    {
        static ModelContainer cont = new ModelContainer();

        public CompanyRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<Company> Companyes()
        {
            return cont.Company.OrderBy(c => c.Id);
        }

        static public Company GetCompany(int id)
        {
            return cont.Company.SingleOrDefault(c => c.Id == id);
        }

        public void DeleteCompany(int id)
        {
            cont.Company.Remove(cont.Company.Find(id));
            cont.SaveChanges();
        }

        public Company AddCompany(string name, string inn, string ogrn, string bankAccaunt)
        {
            Company c = new Company
            {
                Name = name,
                INN = inn,
                OGRN = ogrn,
                BankAccount = bankAccaunt
            };
            cont.Company.Add(c);
            cont.SaveChanges();
            return c;
        }

        public Company EditCompany(int id, string name, string inn, string ogrn, string bankAccaunt)
        {
            Company c = cont.Company.SingleOrDefault(ca => ca.Id == id);
            c.Name = name;
            c.INN = inn;
            c.OGRN = ogrn;
            c.BankAccount = bankAccaunt;
            cont.SaveChanges();
            return c;
        }
    }
}