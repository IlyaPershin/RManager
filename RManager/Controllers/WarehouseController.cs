using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RManager.Models;

namespace RManager.Controllers
{
    public class WarehouseController : Controller
    {
        private DataManager _DataManager;

        public WarehouseController(DataManager _DM)
        {
            _DataManager = _DM;
        }

        public ActionResult Warehouse()
        {
            var purchases = _DataManager.purchaseRepository.Purchases().Where(p => p.Warehouse.Product.IsExist);
            var ejections = _DataManager.ejectionRepository.Ejections().Where(e => e.Warehouse.Product.IsExist);
            var products = _DataManager.warehouseRepository.Warehouses().Where(p => p.Product.IsExist);
            
            SortedDictionary<Warehouse, double> productValues = new SortedDictionary<Warehouse, double>(new WarehouseComparer());
            foreach (Warehouse p in products) productValues.Add(p, !p.FactualNumber.HasValue ? 0 : p.FactualNumber.Value);
            foreach (Purchase p in purchases) if (p.Warehouse.Product.IsIngredient && p.Date > p.Warehouse.InspectionDate) productValues[p.Warehouse] += p.Volume;
            foreach (Ejection e in ejections) if (e.Warehouse.Product.IsIngredient && e.Date > e.Warehouse.InspectionDate) productValues[e.Warehouse] += e.Volume;

            SortedDictionary<Warehouse, double> productValues1 = new SortedDictionary<Warehouse, double>(new WarehouseComparer());
            SortedDictionary<Warehouse, double> productValue2 = new SortedDictionary<Warehouse, double>(new WarehouseComparer());
            foreach (var pv in productValues)
            {
                if (pv.Key.Product.IsIngredient) productValues1.Add(pv.Key, pv.Value);
                if (pv.Key.Product.IsMerchandise) productValue2.Add(pv.Key, pv.Value);
            }
            ViewData["ingredients"] = productValues1;
            ViewData["merchandises"] = productValue2;

            ViewData["prepacks"] = _DataManager.prepackRepository.Prepacks().Where(p => p.IsExist);

            ViewData["Companyes"] = _DataManager.companyRepository.Companyes();

            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult AddIngredient()
        {
            SortedList<int, string> sl = new SortedList<int, string>
            {
                { 0, "Граммы" },
                { 1, "Миллилитры" },
                { 2, "Штуки" }
            };
            ViewData["Measures"] = new SelectList(sl, "Key", "Value");

            sl = new SortedList<int, string>();
            foreach (Company c in _DataManager.companyRepository.Companyes())
            {
                sl.Add(c.Id, c.Name);
            }
            ViewData["Manufacturers"] = new SelectList(sl, "Key", "Value");

            sl = new SortedList<int, string>();
            foreach (Category c in _DataManager.categoryRepository.Categotyes())
            {
                sl.Add(c.Id, c.Name);
            }
            ViewData["Categoryes"] = new SelectList(sl, "Key", "Value");

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddIngredient(string name, string property, string description, string vendorCode, int measure, int manufactorer,
            string lossDuringCleaning, string lossDuringFrying, string otherLosses,
            string cost, string volume, int category, string protains, string fats, string carbohydrates, string energyCalorie, string energyJoule)
        {
            if (string.IsNullOrWhiteSpace(name))
                ModelState.AddModelError("Name", "Введите название продукта");

            if (string.IsNullOrWhiteSpace(property))
                property = " ";

            if (string.IsNullOrWhiteSpace(description))
                property = " ";

            if (string.IsNullOrWhiteSpace(vendorCode))
                ModelState.AddModelError("VendorCode", "Введите артикул продукта");

            if (string.IsNullOrWhiteSpace(protains))
                protains = "0";
            else
            {
                try
                {
                    double co = Convert.ToDouble(protains);
                }
                catch
                {
                    ModelState.AddModelError("Protains", "Введите белки правильно");
                }
            }

            if (string.IsNullOrWhiteSpace(fats))
                fats = "0";
            else
            {
                try
                {
                    double co = Convert.ToDouble(fats);
                }
                catch
                {
                    ModelState.AddModelError("Fats", "Введите жиры правильно");
                }
            }

            if (string.IsNullOrWhiteSpace(carbohydrates))
                carbohydrates = "0";
            else
            {
                try
                {
                    double co = Convert.ToDouble(carbohydrates);
                }
                catch
                {
                    ModelState.AddModelError("Сarbohydrates", "Введите углеводы правильно");
                }
            }

            if (string.IsNullOrWhiteSpace(energyCalorie))
                energyCalorie = "0";
            else
            {
                try
                {
                    double co = Convert.ToDouble(energyCalorie);
                }
                catch
                {
                    ModelState.AddModelError("EnergyCalorie", "Введите ценность правильно");
                }
            }

            if (string.IsNullOrWhiteSpace(energyJoule))
                energyJoule = "0";
            else
            {
                try
                {
                    double co = Convert.ToDouble(energyJoule);
                }
                catch
                {
                    ModelState.AddModelError("EnergyJoule", "Введите ценность правильно");
                }
            }

            bool isIng = (!string.IsNullOrWhiteSpace(lossDuringCleaning) || !string.IsNullOrWhiteSpace(lossDuringFrying) || !string.IsNullOrWhiteSpace(otherLosses));
            bool isMer = (!string.IsNullOrWhiteSpace(cost) || !string.IsNullOrWhiteSpace(volume));
            if (!isMer) isIng = true;
            
            if (isIng)
            {
                if (string.IsNullOrWhiteSpace(lossDuringCleaning))
                    lossDuringCleaning = "0";
                else
                {
                    try
                    {
                        double co = Convert.ToDouble(lossDuringCleaning);
                    }
                    catch
                    {
                        ModelState.AddModelError("LossDuringCleaning", "Введите потери правильно");
                    }
                }

                if (string.IsNullOrWhiteSpace(lossDuringFrying))
                    lossDuringFrying = "0";
                else
                {
                    try
                    {
                        double co = Convert.ToDouble(lossDuringFrying);
                    }
                    catch
                    {
                        ModelState.AddModelError("LossDuringFrying", "Введите потери правильно");
                    }
                }

                if (string.IsNullOrWhiteSpace(otherLosses))
                    otherLosses = "0";
                else
                {
                    try
                    {
                        double co = Convert.ToDouble(otherLosses);
                    }
                    catch
                    {
                        ModelState.AddModelError("OtherLosses", "Введите потери правильно");
                    }
                }
            }

            if (isMer)
            {
                try
                {
                    decimal co = Convert.ToDecimal(cost);
                    if (co <= 0)
                        ModelState.AddModelError("Cost", "Введите цену");
                }
                catch
                {
                    ModelState.AddModelError("Cost", "Введите цену правильно");
                }

                try
                {
                    double co = Convert.ToDouble(volume);
                    if (co <= 0)
                        ModelState.AddModelError("Volume", "Введите количество");
                }
                catch
                {
                    ModelState.AddModelError("Volume", "Введите количество правильно");
                }
            }

            if ((from g in _DataManager.productRepository.Products()
                 where (g.Name == name && g.Property == property && g.Manufacturer.Id == manufactorer)
                 select g).Count() != 0)
                ModelState.AddModelError("Dublicate", "Такой продукт уже есть в базе данных");

            if (ModelState.IsValid)
            {
                if (isIng && isMer)
                    _DataManager.productRepository.AddProduct(name, property, description, Convert.ToDecimal(cost), Convert.ToDouble(volume), true, true,
                        (byte)measure, vendorCode, Convert.ToDouble(lossDuringCleaning), Convert.ToDouble(lossDuringFrying), Convert.ToDouble(otherLosses),
                        Convert.ToDouble(protains), Convert.ToDouble(fats), Convert.ToDouble(carbohydrates), Convert.ToDouble(energyCalorie), Convert.ToDouble(energyJoule),
                        _DataManager.categoryRepository.GetCategory(category), _DataManager.companyRepository.GetCompany(manufactorer));

                if (isIng && !isMer)
                    _DataManager.productRepository.AddIngredient(name, property,
                        (byte)measure, vendorCode, Convert.ToDouble(lossDuringCleaning), Convert.ToDouble(lossDuringFrying), Convert.ToDouble(otherLosses),
                        Convert.ToDouble(protains), Convert.ToDouble(fats), Convert.ToDouble(carbohydrates), Convert.ToDouble(energyCalorie), Convert.ToDouble(energyJoule),
                        _DataManager.companyRepository.GetCompany(manufactorer));

                if (!isIng && isMer)
                    _DataManager.productRepository.AddMercandise(name, property, description, Convert.ToDecimal(cost), Convert.ToDouble(volume),
                        (byte)measure, vendorCode,
                        Convert.ToDouble(protains), Convert.ToDouble(fats), Convert.ToDouble(carbohydrates), Convert.ToDouble(energyCalorie), Convert.ToDouble(energyJoule),
                        _DataManager.categoryRepository.GetCategory(category), _DataManager.companyRepository.GetCompany(manufactorer));

                return RedirectToAction("Warehouse");
            }

            //ViewData["Ingridients"] = new SelectList(_DataManager.IR.Ingridients(), "ID", "Ingridient");
            return View();
        }
    }

    public class WarehouseComparer : IComparer<Warehouse>
    {
        public int Compare(Warehouse x, Warehouse y)
        {
            return x.Product.Name.CompareTo(y.Product.Name);
        }
    }
}