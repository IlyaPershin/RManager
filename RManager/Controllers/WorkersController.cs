using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RManager.Models;

namespace RManager.Controllers
{
    public class WorkersController : Controller
    {
        private DataManager _DataManager;

        public WorkersController(DataManager _DM)
        {
            _DataManager = _DM;
        }

        public ActionResult Workers()
        {
            SortedList<int, Employee> employees = new SortedList<int, Employee>();

            foreach (var e in _DataManager.employeeRepository.Employees())
            {
                if (e.IsWorking && e.Position.Name != "Суперпользователь" && e.Id != ((Employee)Session["user"]).Id)
                    employees.Add(e.Id, e);
            }

            ViewData["employees"] = employees;

            SortedList<int, Position> positions = new SortedList<int, Position>();

            foreach (var p in _DataManager.positionRepository.Positions())
            {
                if (p.Name != "Суперпользователь" && p.Id != ((Employee)Session["user"]).Position.Id)
                    positions.Add(p.Id, p);
            }

            ViewData["positions"] = positions;

            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult AddWorker()
        {
            SortedList<int, string> sl = new SortedList<int, string>();
            foreach (Position c in _DataManager.positionRepository.Positions())
            {
                if (c.Name != "Суперпользователь")
                sl.Add(c.Id, c.Name);
            }
            ViewData["Positions"] = new SelectList(sl, "Key", "Value");
            
            sl = new SortedList<int, string>();
            foreach (Branch c in _DataManager.branchRepository.Branches())
            {
                sl.Add(c.Id, c.Adress.Street + ' ' + c.Adress.Bilding);
            }
            ViewData["Branches"] = new SelectList(sl, "Key", "Value");

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddWorker(string surname, string firstname, string middlename, string phone, string email, 
            string login, string password, string description, int branch, int position,
            string country, string city, string street, string building, string index)
        {
            if (string.IsNullOrWhiteSpace(surname))
                ModelState.AddModelError("Surname", "Введите имя пользователя");

            if (string.IsNullOrWhiteSpace(firstname))
                ModelState.AddModelError("Firstname", "Введите фамилию пользователя");

            if (string.IsNullOrWhiteSpace(middlename))
                middlename = "";

            if (string.IsNullOrWhiteSpace(phone))
                ModelState.AddModelError("Phone", "Введите телефон пользователя");

            if (string.IsNullOrWhiteSpace(email))
                ModelState.AddModelError("Email", "Введите электронную почту пользователя");

            if (string.IsNullOrWhiteSpace(login))
                ModelState.AddModelError("Login", "Введите логин пользователя");

            if (_DataManager.employeeRepository.Employees().Any(e => e.IsWorking && e.Login == login))
                ModelState.AddModelError("Login", "Введён не уникальный логин");

            if (string.IsNullOrWhiteSpace(password))
                ModelState.AddModelError("Password", "Введите пароль пользователя");

            if (string.IsNullOrWhiteSpace(country))
                country = "";

            if (string.IsNullOrWhiteSpace(city))
                city = "";

            if (string.IsNullOrWhiteSpace(street))
                street = "";

            if (string.IsNullOrWhiteSpace(building))
                building = "";

            if (string.IsNullOrWhiteSpace(index))
                index = "";



            if ((from g in _DataManager.employeeRepository.Employees()
                 where (g.Login == login)
                 select g).Count() != 0)
                ModelState.AddModelError("Dublicate", "Такой пользователь уже есть в базе");

            if (ModelState.IsValid)
            {
                _DataManager.employeeRepository.AddEmployee(surname, firstname, middlename, phone, email,
                    country, city, street, building, index,
                    login, password.GetHashCode().ToString(), description, 
                    _DataManager.branchRepository.GetBranchById(branch), _DataManager.positionRepository.GetPosition(position));

                return RedirectToAction("Workers");
            }

            //ViewData["Ingridients"] = new SelectList(_DataManager.IR.Ingridients(), "ID", "Ingridient");
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult AddPosition()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddPosition(string name, bool? orders, bool? menu, bool? warehouse, bool? workers, bool? tables, bool? reports)
        {
            if (string.IsNullOrWhiteSpace(name))
                ModelState.AddModelError("Name", "Введите название должности");

            if ((from g in _DataManager.productRepository.Products()
                 where (g.Name == name)
                 select g).Count() != 0)
                ModelState.AddModelError("Dublicate", "Такая должность уже есть в базе");

            orders = orders.HasValue ? orders.Value : false;
            menu = menu.HasValue ? menu.Value : false;
            warehouse = warehouse.HasValue ? warehouse.Value : false;
            workers = workers.HasValue ? workers.Value : false;
            tables = tables.HasValue ? tables.Value : false;
            reports = reports.HasValue ? reports.Value : false;

            if (ModelState.IsValid)
            {
                _DataManager.positionRepository.AddPosition(name, orders.Value, menu.Value, warehouse.Value, workers.Value, tables.Value, reports.Value);
                return RedirectToAction("Workers");
            }

            //ViewData["Ingridients"] = new SelectList(_DataManager.IR.Ingridients(), "ID", "Ingridient");
            return View();
        }
    }
}