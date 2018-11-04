using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class OrdersController : Controller
    {
        private WebStoreContext db = new WebStoreContext();

        public ActionResult Index()
        {
            return View("Manage", db.Orders.Where(x => !x.IsDeleted).ToList());
        }

        [HttpPost]
        public ActionResult Delete(string orderID)
        {
            Order order = db.Orders.Find(int.Parse(orderID));
            order.IsDeleted = true;
            db.SaveChanges();
            return Json(new { Success = true });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}