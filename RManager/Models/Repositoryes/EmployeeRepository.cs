using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RManager.Models.Repositoryes
{
    public class EmployeeRepository
    {
        static ModelContainer cont = new ModelContainer();

        public EmployeeRepository(ModelContainer _cont)
        {
            cont = _cont;
        }

        public IEnumerable<Employee> Employees()
        {
            var persons = cont.Person.ToList().FindAll(cp => cp is Employee || cp is CompanyOwner);
            List<Employee> employees = new List<Employee>();
            foreach (var pers in persons)
            {
                employees.Add((Employee)pers);
            }
            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            return (Employee)cont.Person.SingleOrDefault(c => c.Id == id);
        }

        public Employee GetEmployeeByName(string name)
        {
            return (Employee)cont.Person.SingleOrDefault(p => p.Surname == name || p.FirstName == name);
        }

        public Employee GetEmployeeByPhone(string phone)
        {
            return (Employee)cont.Person.SingleOrDefault(p => p.Phone == phone);
        }

        public Employee GetEmployeeByEmail(string email)
        {
            return (Employee)cont.Person.SingleOrDefault(p => p.Email == email);
        }

        public void DeleteEmployee(int id)
        {
            if (cont.Order.ToList().Exists(o => o.Employee.Id == id) ||
                cont.Shift.ToList().Exists(o => o.Person.Id == id))
            {
                ((Employee)cont.Person.SingleOrDefault(p => p.Id == id)).IsWorking = false;
                return;
            }
            cont.Person.Remove(cont.Person.Find(id));
            cont.SaveChanges();
        }

        public Employee AddEmployee(string surname, string firstname, string middlename, string phone, string email,
            string country, string city, string street, string building, string index,
            string login, string password, string description, Branch branch, Position position)
        {

            Employee p = new Employee
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

                Branch = branch,
                Position = position,
            };
            cont.Person.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Employee AddEmployee(string surname, string firstname, string middlename, string phone, string email,
            Adress adress,
            string login, string password, string description, Branch branch, Position position)
        {

            Employee p = new Employee
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

                Branch = branch,
                Position = position,
            };
            cont.Person.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Employee AddEmployee(string surname, string firstname, string middlename, string phone, string email,
            string login, string password, string description, Branch branch, Position position)
        {

            Employee p = new Employee
            {
                Surname = surname,
                FirstName = firstname,
                MiddleName = middlename,
                Phone = phone,
                Email = email,

                Adress = null,

                Login = login,
                Password = password,
                IsWorking = true,
                Description = description,

                Branch = branch,
                Position = position,
            };
            cont.Person.Add(p);
            cont.SaveChanges();
            return p;
        }

        public Person EditPerson(int id, string surname, string firstname, string middlename, string phone, string email,
            string country, string city, string street, string building, string index,
            string login, string password, bool isWorking, string description, Branch branch)
        {
            Employee p = (Employee)cont.Person.SingleOrDefault(ca => ca.Id == id);

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
            p.Branch = branch;
            cont.SaveChanges();
            return p;
        }

        public Employee EditEmployee(int id, string surname, string firstname, string middlename, string phone, string email,
            Adress adress,
            string login, string password, bool isWorking, string description, Branch branch)
        {
            Employee p = (Employee)cont.Person.SingleOrDefault(ca => ca.Id == id);

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
            p.Branch = branch;
            cont.SaveChanges();
            return p;
        }

        public Employee EditEmployee(int id, string surname, string firstname, string middlename, string phone, string email,
            string login, string password, bool isWorking, string description, Branch branch)
        {
            Employee p = (Employee)cont.Person.SingleOrDefault(ca => ca.Id == id);

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
            p.Branch = branch;
            cont.SaveChanges();
            return p;
        }
    }
}