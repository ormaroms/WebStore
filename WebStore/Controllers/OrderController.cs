using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View("Index", (List<Item>)Session["UserOrder"]);
        }

        [HttpPost]
        public ActionResult DeleteItem(int itemID, string actionName)
        {
            List<Item> myOrders = (List<Item>)Session["UserOrder"];

            if (itemID != null)
            {
                myOrders.RemoveAll(r => r.ItemID == itemID);
            }

            Session["UserOrder"] = myOrders;

            return RedirectToAction(actionName);
        }
    }
}