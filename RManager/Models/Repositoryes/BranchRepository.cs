using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class BranchRepository
    {
        static ModelContainer cont = new ModelContainer();

        public BranchRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<Branch> Branches()
        {
            return cont.Branch.OrderBy(b => b.Id);
        }

        public Branch GetBranchById(int id)
        {
            return cont.Branch.SingleOrDefault(b => b.Id == id);
        }

        public IEnumerable<Branch> GetBranchesByAdress(Adress adress)
        {
            IEnumerable<Branch> branches = cont.Branch.ToList().FindAll(b => b.Adress == adress);
            if (branches.Count() > 0)
                return branches;

            branches = new List<Branch>();
            if (adress.Country != null && adress.Country != "")
                branches.Concat(cont.Branch.ToList().FindAll(b => b.Adress.Country == adress.Country));

            if (adress.City != null && adress.City != "")
                branches.Concat(cont.Branch.ToList().FindAll(b => b.Adress.City == adress.City));

            if (adress.Street != null && adress.Street != "")
                branches.Concat(cont.Branch.ToList().FindAll(b => b.Adress.Street == adress.Street));

            if (adress.Bilding != null && adress.Bilding != "")
                branches.Concat(cont.Branch.ToList().FindAll(b => b.Adress.Bilding == adress.Bilding));

            if (adress.Index != null && adress.Index != "")
                branches.Concat(cont.Branch.ToList().FindAll(b => b.Adress.Index == adress.Index));

            branches.Distinct();
            return branches;
        }

        public Branch GetBranchByPhone(string phone)
        {
            return cont.Branch.SingleOrDefault(b => b.Phone == phone);
        }

        public Branch GetBranchByEmail(string website)
        {
            return cont.Branch.SingleOrDefault(b => b.WebSite == website);
        }

        public Branch GetBranchByOwner(CompanyOwner companyOwner)
        {
            return cont.Branch.SingleOrDefault(b => b.Owner == companyOwner);
        }

        public Branch GetBranchByLandlord(Landlord landlord)
        {
            return cont.Branch.SingleOrDefault(b => b.Landlord == landlord);
        }

        public void DeleteBranch(int id)
        {
            cont.Branch.Remove(cont.Branch.Find(id));
            cont.SaveChanges();
        }

        public Branch AddBranch(string website, string phone, DateTime startWorkingTime, DateTime endtWorkingTime,
            string country, string city, string street, string building, string index,
            CompanyOwner owner, Landlord landlord)
        {

            Branch b = new Branch
            {
                WebSite = website,
                Phone = phone,
                StartWorkingTime = new TimeSpan(startWorkingTime.Hour, startWorkingTime.Minute, startWorkingTime.Second),
                EndWorkingTime = new TimeSpan(endtWorkingTime.Hour, endtWorkingTime.Minute, endtWorkingTime.Second),

                Adress =
                {
                    Country = country,
                    City = city,
                    Street = street,
                    Bilding = building,
                    Index = index
                },

                Owner = owner,
                Landlord = landlord,
            };
            cont.Branch.Add(b);
            cont.SaveChanges();
            return b;
        }

        public Branch AddBranch(string website, string phone, DateTime startWorkingTime, DateTime endtWorkingTime,
            Adress adress,
            CompanyOwner owner, Landlord landlord)
        {

            Branch b = new Branch
            {
                WebSite = website,
                Phone = phone,
                StartWorkingTime = new TimeSpan(startWorkingTime.Hour, startWorkingTime.Minute, startWorkingTime.Second),
                EndWorkingTime = new TimeSpan(endtWorkingTime.Hour, endtWorkingTime.Minute, endtWorkingTime.Second),

                Adress = adress,

                Owner = owner,
                Landlord = landlord,
            };
            cont.Branch.Add(b);
            cont.SaveChanges();
            return b;
        }

        public Branch EditBranch(int id, string website, string phone, DateTime startWorkingTime, DateTime endtWorkingTime,
            string country, string city, string street, string building, string index,
            CompanyOwner owner, Landlord landlord)
        {
            Branch b = cont.Branch.SingleOrDefault(ca => ca.Id == id);

            b.WebSite = website;
            b.Phone = phone;
            b.StartWorkingTime = new TimeSpan(startWorkingTime.Hour, startWorkingTime.Minute, startWorkingTime.Second);
            b.EndWorkingTime = new TimeSpan(endtWorkingTime.Hour, endtWorkingTime.Minute, endtWorkingTime.Second);

            b.Adress = new Adress
            {
                Country = country,
                City = city,
                Street = street,
                Bilding = building,
                Index = index
            };

            b.Owner = owner;
            b.Landlord = landlord;

            cont.SaveChanges();
            return b;
        }

        public Branch EditBranch(int id, string website, string phone, DateTime startWorkingTime, DateTime endtWorkingTime,
            Adress adress,
            CompanyOwner owner, Landlord landlord)
        {
            Branch b = cont.Branch.SingleOrDefault(ca => ca.Id == id);

            b.WebSite = website;
            b.Phone = phone;
            b.StartWorkingTime = new TimeSpan(startWorkingTime.Hour, startWorkingTime.Minute, startWorkingTime.Second);
            b.EndWorkingTime = new TimeSpan(endtWorkingTime.Hour, endtWorkingTime.Minute, endtWorkingTime.Second);

            b.Adress = adress;

            b.Owner = owner;
            b.Landlord = landlord;

            cont.SaveChanges();
            return b;
        }
    }
}