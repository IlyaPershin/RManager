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

        public Company AddCompany(string name)
        {
            Company c = new Company
            {
                Name = name,
                //ParrentCompany = null
            };
            cont.Company.Add(c);
            cont.SaveChanges();
            return c;
        }

        public Company AddCompany(string name, Company parrent)
        {
            Company c = new Company
            {
                Name = name,
                //ParrentCompany = parrent
            };
            cont.Company.Add(c);
            cont.SaveChanges();
            return c;
        }

        public Company AddCompany(string name, int parrent)
        {
            Company c = new Company
            {
                Name = name,
                //ParrentCompany = cont.Company.SingleOrDefault(ca => ca.Id == parrent)
            };
            cont.Company.Add(c);
            cont.SaveChanges();
            return c;
        }

        public Company EditCompany(int id, string name, Company parrent)
        {
            Company c = cont.Company.SingleOrDefault(ca => ca.Id == id);
            c.Name = name;
            //c.ParrentCompany = parrent;
            cont.SaveChanges();
            return c;
        }

        public Company EditCompany(int id, string name, int parrent)
        {
            Company c = cont.Company.SingleOrDefault(ca => ca.Id == id);
            c.Name = name;
            //c.ParrentCompany = cont.Company.SingleOrDefault(ca => ca.Id == parrent);
            cont.SaveChanges();
            return c;
        }
    }
}