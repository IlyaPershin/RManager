using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RManager.Models;

namespace RManager.Controllers
{
    public class CompanyesController : Controller
    {
        private DataManager _DataManager;

        public CompanyesController(DataManager _DM)
        {
            _DataManager = _DM;
        }

        public ActionResult Companyes()
        {
            SortedList<int, Company> companyes = new SortedList<int, Company>();
            
            foreach (var c in _DataManager.companyRepository.Companyes())
            {
                companyes.Add(c.Id, c);
            }

            ViewData["companyes"] = companyes;

            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult AddCompany()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddCompany(string name, string inn, string ogrn, string bankAccount)
        {
            if (string.IsNullOrWhiteSpace(name))
                ModelState.AddModelError("Name", "Введите название компании");

            if (string.IsNullOrWhiteSpace(inn))
                ModelState.AddModelError("INN", "Введите ИНН компании");

            if (string.IsNullOrWhiteSpace(ogrn))
                ModelState.AddModelError("OGRN", "Введите ОГРН компании");

            if (string.IsNullOrWhiteSpace(bankAccount))
                ModelState.AddModelError("BankAccount", "Введите банковский счёт компании");
            
            
            if ((from g in _DataManager.companyRepository.Companyes()
                 where (g.Name == name)
                 select g).Count() != 0)
                ModelState.AddModelError("Dublicate", "Такая компания уже есть в базе данных");

            if (ModelState.IsValid)
            {
                _DataManager.companyRepository.AddCompany(name, inn, ogrn, bankAccount);

                return RedirectToAction("Companyes");
            }
            
            return View();
        }

        public ActionResult DeleteCompany(int id)
        {
            _DataManager.companyRepository.DeleteCompany(id);
            return RedirectToAction("Companyes");
        }
    }
}