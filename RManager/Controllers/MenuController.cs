using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RManager.Models;

namespace RManager.Controllers
{
    public class MenuController : Controller
    {
        private DataManager _DataManager;

        public MenuController(DataManager _DM)
        {
            _DataManager = _DM;
        }

        public ActionResult Menu()
        {
            ViewData["Dishes"] = _DataManager.dishRepository.Dishes();
            ViewData["Ingrediets"] = _DataManager.productRepository.Products();
            ViewData["Categoryes"] = _DataManager.categoryRepository.Categotyes();
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult AddDish()
        {
            SortedList<int, string> sl = new SortedList<int, string>
            {
                { 0, "Граммы" },
                { 1, "Миллилитры" },
                { 2, "Штуки" }
            };
            ViewData["Measures"] = new SelectList(sl, "Key", "Value");

            sl = new SortedList<int, string>();
            foreach (Product c in _DataManager.productRepository.Products())
            {
                sl.Add(c.Id, c.Name + "; " + c.Property + "; " + c.Manufacturer.Name + "; " + c.Measure.ToString());
            }
            ViewData["Products"] = new SelectList(sl, "Key", "Value");

            sl = new SortedList<int, string>();
            foreach (Prepack c in _DataManager.prepackRepository.Prepacks())
            {
                sl.Add(c.Id, c.Name);
            }
            ViewData["Prepacks"] = new SelectList(sl, "Key", "Value");

            sl = new SortedList<int, string>();
            foreach (Room c in _DataManager.roomRepository.Rooms())
            {
                sl.Add(c.Id, c.Name);
            }
            ViewData["Rooms"] = new SelectList(sl, "Key", "Value");

            sl = new SortedList<int, string>();
            foreach (Category c in _DataManager.categoryRepository.Categotyes())
            {
                sl.Add(c.Id, c.Name);
            }
            ViewData["Categoryes"] = new SelectList(sl, "Key", "Value");

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddDish(string dishname, string description, string cost, string volume, int measure,
            string vendorCode,
            string protains, string fats, string carbohydrates, string energyCalorie, string energyJoule,
            int room, int category,
            bool checkP1, int product1, string volumeP1,
            bool checkP2, int product2, string volumeP2,
            bool checkP3, int product3, string volumeP3,
            bool checkP4, int product4, string volumeP4,
            bool checkP5, int product5, string volumeP5,
            bool checkP6, int product6, string volumeP6,
            bool checkP7, int product7, string volumeP7,
            bool checkP8, int product8, string volumeP8,
            bool checkP9, int product9, string volumeP9,
            bool checkP10, int product10, string volumeP10)
        {
            if (string.IsNullOrWhiteSpace(dishname))
                ModelState.AddModelError("Dishname", "Введите название");

            if (string.IsNullOrWhiteSpace(description))
                description = " ";

            decimal co = 0;
            try
            {
                co = Convert.ToDecimal(cost);
            }
            catch (FormatException)
            {
                ModelState.AddModelError("Cost", "Введите цену правильно");
            }

            if (string.IsNullOrWhiteSpace(cost))
                ModelState.AddModelError("Cost", "Введите цену");

            double vo = 0;
            try
            {
                vo = Convert.ToDouble(volume);
            }
            catch (FormatException)
            {
                ModelState.AddModelError("Volume", "Введите количество правильно");
            }

            if (string.IsNullOrWhiteSpace(volume))
                ModelState.AddModelError("Volume", "Введите количество");

            if (string.IsNullOrWhiteSpace(vendorCode))
                ModelState.AddModelError("VendorCode", "Введите артикул продукта");

            if (string.IsNullOrWhiteSpace(protains))
                protains = "0";
            else
            {
                
                try
                {
                    double p = Convert.ToDouble(protains);
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
                    double f = Convert.ToDouble(fats);
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
                    double c = Convert.ToDouble(carbohydrates);
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
                    double e = Convert.ToDouble(energyCalorie);
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
                    double e = Convert.ToDouble(energyJoule);
                }
                catch
                {
                    ModelState.AddModelError("EnergyJoule", "Введите ценность правильно");
                }
            }

            #region products

            Dictionary<int, double> products = new Dictionary<int, double>();
            if (checkP1)
            {
                double p = 0;
                try
                {
                    p = Convert.ToDouble(volumeP1);
                }
                catch (FormatException)
                {
                    ModelState.AddModelError("Product1", "Введите количество правильно");
                }

                if (string.IsNullOrWhiteSpace(volumeP1))
                    ModelState.AddModelError("Product1", "Введите количество");

                if (p != 0) products.Add(product1, p);
            }

            if (checkP2)
            {
                double p = 0;
                try
                {
                    p = Convert.ToDouble(volumeP2);
                }
                catch (FormatException)
                {
                    ModelState.AddModelError("Product2", "Введите количество правильно");
                }

                if (string.IsNullOrWhiteSpace(volumeP2))
                    ModelState.AddModelError("Product2", "Введите количество");

                if (p != 0) products.Add(product2, p);
            }

            if (checkP3)
            {
                double p = 0;
                try
                {
                    p = Convert.ToDouble(volumeP3);
                }
                catch (FormatException)
                {
                    ModelState.AddModelError("Product3", "Введите количество правильно");
                }

                if (string.IsNullOrWhiteSpace(volumeP3))
                    ModelState.AddModelError("Product3", "Введите количество");

                if (p != 0) products.Add(product3, p);
            }

            if (checkP4)
            {
                double p = 0;
                try
                {
                    p = Convert.ToDouble(volumeP4);
                }
                catch (FormatException)
                {
                    ModelState.AddModelError("Product4", "Введите количество правильно");
                }

                if (string.IsNullOrWhiteSpace(volumeP4))
                    ModelState.AddModelError("Product4", "Введите количество");

                if (p != 0) products.Add(product4, p);
            }

            if (checkP5)
            {
                double p = 0;
                try
                {
                    p = Convert.ToDouble(volumeP5);
                }
                catch (FormatException)
                {
                    ModelState.AddModelError("Product5", "Введите количество правильно");
                }

                if (string.IsNullOrWhiteSpace(volumeP5))
                    ModelState.AddModelError("Product5", "Введите количество");

                if (p != 0) products.Add(product5, p);
            }

            if (checkP6)
            {
                double p = 0;
                try
                {
                    p = Convert.ToDouble(volumeP6);
                }
                catch (FormatException)
                {
                    ModelState.AddModelError("Product6", "Введите количество правильно");
                }

                if (string.IsNullOrWhiteSpace(volumeP6))
                    ModelState.AddModelError("Product6", "Введите количество");

                if (p != 0) products.Add(product6, p);
            }

            if (checkP7)
            {
                double p = 0;
                try
                {
                    p = Convert.ToDouble(volumeP7);
                }
                catch (FormatException)
                {
                    ModelState.AddModelError("Product7", "Введите количество правильно");
                }

                if (string.IsNullOrWhiteSpace(volumeP7))
                    ModelState.AddModelError("Product7", "Введите количество");

                if (p != 0) products.Add(product7, p);
            }

            if (checkP8)
            {
                double p = 0;
                try
                {
                    p = Convert.ToDouble(volumeP8);
                }
                catch (FormatException)
                {
                    ModelState.AddModelError("Product8", "Введите количество правильно");
                }

                if (string.IsNullOrWhiteSpace(volumeP8))
                    ModelState.AddModelError("Product8", "Введите количество");

                if (p != 0) products.Add(product8, p);
            }

            if (checkP9)
            {
                double p = 0;
                try
                {
                    p = Convert.ToDouble(volumeP9);
                }
                catch (FormatException)
                {
                    ModelState.AddModelError("Product9", "Введите количество правильно");
                }

                if (string.IsNullOrWhiteSpace(volumeP9))
                    ModelState.AddModelError("Product9", "Введите количество");

                if (p != 0) products.Add(product9, p);
            }

            if (checkP10)
            {
                double p = 0;
                try
                {
                    p = Convert.ToDouble(volumeP10);
                }
                catch (FormatException)
                {
                    ModelState.AddModelError("Product10", "Введите количество правильно");
                }

                if (string.IsNullOrWhiteSpace(volumeP10))
                    ModelState.AddModelError("Product10", "Введите количество");

                if (p != 0) products.Add(product10, p);
            }

            #endregion


            if ((from g in _DataManager.dishRepository.Dishes()
                 where (g.Name == dishname && g.Category.Id == category)
                 select g).Count() != 0)
                ModelState.AddModelError("Dublicate", "Блюдо с таким названием уже есть в этой категории");

            if (ModelState.IsValid)
            {
                var dish = _DataManager.dishRepository.AddDish(dishname, description, co, vo, (byte)measure, vendorCode,
                    new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, 0), 
                    new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59, 999),
                    Convert.ToDouble(protains), Convert.ToDouble(fats), Convert.ToDouble(carbohydrates), Convert.ToDouble(energyCalorie), Convert.ToDouble(energyJoule),
                    _DataManager.roomRepository.GetRoomById(room), _DataManager.categoryRepository.GetCategory(category));

                foreach(var p in products)
                {
                    _DataManager.recipeDishIngrRepository.AddRecipeDishIngr(p.Value, "", _DataManager.productRepository.GetProductById(p.Key), dish);
                }

                return RedirectToAction("Menu");
            }

            //ViewData["Ingridients"] = new SelectList(_DataManager.IR.Ingridients(), "ID", "Ingridient");
            return View();
        }
    }
}