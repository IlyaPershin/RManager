using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RManager.Models;

namespace RManager.Controllers
{
    public class ReportsController : Controller
    {
        private DataManager _DataManager;

        public ReportsController(DataManager _DM)
        {
            _DataManager = _DM;
        }

        public ActionResult Reports()
        {
            return View();
        }
    }
}