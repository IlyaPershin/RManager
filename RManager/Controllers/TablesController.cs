using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RManager.Models;

namespace RManager.Controllers
{
    public class TablesController : Controller
    {
        private DataManager _DataManager;

        public TablesController(DataManager _DM)
        {
            _DataManager = _DM;
        }

        public ActionResult Tables()
        {
            ViewData["Tables"] = _DataManager.tableRepository.Tables();
            return View();
        }
    }
}