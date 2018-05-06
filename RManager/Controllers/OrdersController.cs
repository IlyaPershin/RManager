using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RManager.Models;

namespace RManager.Controllers
{
    public class OrdersController : Controller
    {
        private DataManager _DataManager;

        public OrdersController(DataManager _DM)
        {
            _DataManager = _DM;
        }
        
        public ActionResult Orders()
        {
            ViewData["Orders"] = (from g in _DataManager.orderRepository.Orders()
                                  where g.IsOpen
                                  select g);
            return View();
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult NewOrder()
        {
            SortedList<int, string> sl = new SortedList<int, string>();
            foreach (var t in _DataManager.tableRepository.Tables())
            {
                sl.Add(t.Id, t.Number.ToString());
            }
            ViewData["Tables"] = new SelectList(sl, "Key", "Value");

            sl = new SortedList<int, string>();
            foreach (var c in _DataManager.clientRepository.Clients())
            {
                sl.Add(c.Id, c.Surname);
            }
            ViewData["Clients"] = new SelectList(sl, "Key", "Value");

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult NewOrder(int tableNumber, int client)
        {
            //int idOrder = _DataManager.orderRepository.AddOrder((Employee)Session["user"], _DataManager.tableRepository.GetTableById(tableNumber), 
            //    _DataManager.clientRepository.GetClientById(client)).Id;
            int idOrder = _DataManager.orderRepository.AddOrder(((Employee)Session["user"]).Id, tableNumber, client).Id;

            return RedirectToAction("EditOrder", new { idOrder = idOrder }); ;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult EditOrder(int idOrder)
        {
            ViewData.Model = _DataManager.orderRepository.GetOrderById(idOrder);
            ViewData["ChecksDish"] = (from g in _DataManager.checkDishRepository.Checks()
                                      where g.Order.Id == idOrder
                                      select g).ToList();
            ViewData["ChecksMerchandize"] = (from g in _DataManager.checkMerchandiseRepository.Checks()
                                             where g.Order.Id == idOrder
                                             select g).ToList();

            ViewData["Dishes"] = (from g in _DataManager.dishRepository.Dishes()
                                  where g.IsExist
                                  select g).ToList();
            ViewData["Merchandizes"] = (from g in _DataManager.productRepository.Products()
                                        where g.IsExist && g.IsMerchandise
                                        select g).ToList();
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditOrder()
        {
            return RedirectToAction("WaiterMainWindow");
        }

        public ActionResult DeleteDish(int idCheck, int idOrder)
        {
            _DataManager.checkDishRepository.DeleteCheck(idCheck);
            return RedirectToAction("EditOrder", new { idOrder = idOrder });
        }

        public ActionResult AddDish(int idDish, int idOrder)
        {
            _DataManager.checkDishRepository.AddCheck(_DataManager.dishRepository.GetDishById(idDish), _DataManager.orderRepository.GetOrderById(idOrder));
            Order ord = _DataManager.orderRepository.GetOrderById(idOrder);
            _DataManager.orderRepository.EditOrder(idOrder, ord.FinalPrice + _DataManager.dishRepository.GetDishById(idDish).Cost, null, null, null);
            return RedirectToAction("EditOrder", new { idOrder = idOrder });
        }

        public ActionResult PaidDish(int idCheck, int idOrder)
        {
            _DataManager.checkDishRepository.PaidCheck(idCheck);
            return RedirectToAction("EditOrder", new { idOrder = idOrder });
        }

        public ActionResult PaidDish(int idCheck, int idOrder, decimal finalCost)
        {
            _DataManager.checkDishRepository.PaidCheck(idCheck, finalCost);
            Order ord = _DataManager.orderRepository.GetOrderById(idOrder);
            CheckDish checkDish = _DataManager.checkDishRepository.GetCheckById(idCheck);
            _DataManager.orderRepository.EditOrder(idOrder, ord.FinalPrice - checkDish.Dish.Cost + finalCost, null, null, null);
            return RedirectToAction("EditOrder", new { idOrder = idOrder });
        }

        public ActionResult DeleteMerch(int idCheck, int idOrder)
        {
            _DataManager.checkMerchandiseRepository.DeleteCheck(idCheck);
            return RedirectToAction("EditOrder", new { idOrder = idOrder });
        }

        public ActionResult AddMerch(int idMerch, int idOrder)
        {
            _DataManager.checkMerchandiseRepository.AddCheck(_DataManager.productRepository.GetProductById(idMerch), _DataManager.orderRepository.GetOrderById(idOrder));
            Order ord = _DataManager.orderRepository.GetOrderById(idOrder);
            _DataManager.orderRepository.EditOrder(idOrder, ord.FinalPrice + _DataManager.productRepository.GetProductById(idMerch).Cost, null, null, null);
            return RedirectToAction("EditOrder", new { idOrder = idOrder });
        }

        public ActionResult PaidMerch(int idCheck, int idOrder)
        {
            _DataManager.checkMerchandiseRepository.PaidCheck(idCheck);
            return RedirectToAction("EditOrder", new { idOrder = idOrder });
        }

        public ActionResult PaidMerch(int idCheck, int idOrder, decimal finalCost)
        {
            _DataManager.checkMerchandiseRepository.PaidCheck(idCheck, finalCost);
            Order ord = _DataManager.orderRepository.GetOrderById(idOrder);
            CheckMerchandise checkMerchandise = _DataManager.checkMerchandiseRepository.GetCheckById(idCheck);
            _DataManager.orderRepository.EditOrder(idOrder, ord.FinalPrice - checkMerchandise.Product.Cost + finalCost, null, null, null);
            return RedirectToAction("EditOrder", new { idOrder = idOrder });
        }

        public ActionResult CloseOrder(int idOrder)
        {
            Order order = _DataManager.orderRepository.GetOrderById(idOrder);
            _DataManager.orderRepository.CloseOrder(idOrder, order.FinalPrice);

            foreach (var c in _DataManager.checkDishRepository.GetChecksByOrder(order, null))
            {
                if (!c.IsPaid)
                {
                    c.IsPaid = true;
                    c.PaidDateTime = DateTime.Now;
                    c.FinalPrice = c.Dish.Cost;
                }
            }

            foreach (var c in _DataManager.checkMerchandiseRepository.GetChecksByOrder(order, null))
            {
                if (!c.IsPaid)
                {
                    c.IsPaid = true;
                    c.PaidDateTime = DateTime.Now;
                    c.FinalPrice = c.Product.Cost;
                }
            }

            return RedirectToAction("Orders");
        }

        public ActionResult DeleteOrder(int idOrder)
        {
            _DataManager.orderRepository .DeleteOrder(idOrder);
            return RedirectToAction("Orders");
        }
    }
}