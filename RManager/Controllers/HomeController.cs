using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RManager.Models;

namespace RManager.Controllers
{
    public class HomeController : Controller
    {
        private DataManager _DataManager;

        public HomeController(DataManager _DM)
        {
            _DataManager = _DM;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Login()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Login(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login))
                ModelState.AddModelError("Login", "Введите логин");

            if (string.IsNullOrWhiteSpace(password))
                ModelState.AddModelError("Password", "Введите пароль");

            var employees = (from g in _DataManager.employeeRepository.Employees()
                             where (g.Login == login)
                             select g);

            Employee employee = new Employee();

            if (employees.Count() == 0)
                ModelState.AddModelError("Login", "Пользователя с таким логином нету");
            else
            {
                employee = employees.ElementAt(0);

                if (employee.Password != password.GetHashCode().ToString())
                    ModelState.AddModelError("Password", "Введён не верный пароль");
            }
            
            if (ModelState.IsValid)
            {
                Session["user"] = employee;
                Session["userType"] = employee.GetType().Name.Substring(0, employee.GetType().Name.IndexOf('_'));
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Exit(string name, string password)
        {
            Session.Remove("user");
            Session.Remove("userType");
            Session.Remove("userName");
            Session.Remove("position");
            return RedirectToAction("Index");
        }
    }
}