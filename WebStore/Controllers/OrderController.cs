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
		private WebStoreContext db = new WebStoreContext();

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
                var itemToRemove = myOrders.FirstOrDefault(r => r.ItemID == itemID);
                myOrders.Remove(itemToRemove);
            }

            Session["UserOrder"] = myOrders;

            return RedirectToAction(actionName);
        }

		public ActionResult Checkout()
		{
			return View("Checkout", db.PickUpPoints.Where(x => !x.IsDeleted).ToList());
		}

		public ActionResult SaveOrder(int pickupPoint)
		{
			Dictionary<int, Order> newOrderItems = new Dictionary<int, Order>();
			int userId = (int)Session["UserID"];

			List<Item> orderItems = (List<Item>)Session["UserOrder"];
			Session["UserOrder"] = null;

			// Get order sequence
			int nextSeq = db.Sequences.Select(x => x.OrderSeq).ToList()[0];
			db.Sequences.Where(x => true).ToList()[0].OrderSeq = nextSeq + 1;

			orderItems.ForEach(item =>
			{
				if (!newOrderItems.ContainsKey(item.ItemID))
				{
					Order newOrderRow = new Order()
					{
						OrderID = nextSeq,
						UserID = userId,
						OrderDate = DateTime.Now,
						ItemID = item.ItemID,
						Quantity = 1,
						PickUpPointID = pickupPoint
					};
					newOrderItems.Add(item.ItemID, newOrderRow);
				}
				else
				{
					Order orderToUpdate = newOrderItems.First(x => x.Key == item.ItemID).Value;
					orderToUpdate.Quantity++;
					newOrderItems.Remove(item.ItemID);
					newOrderItems.Add(item.ItemID, orderToUpdate);
				}
			});

			newOrderItems.Values.ToList().ForEach(orderRow =>
			{
				db.Orders.Add(orderRow);
				db.SaveChanges();
			});

			return View("Completed");
		}

		[HttpPost]
		public ActionResult GetUserName()
		{
            int userId = (int)Session["UserID"];
            string name = db.Users.Where(x => x.UserID == userId).Select(x => x.UserName).ToList()[0];
			return Json(name);
		}

		[HttpPost]
		public ActionResult GetTotalPrice()
		{
			double totalPrice = 0;
			((List<Item>)Session["UserOrder"]).ForEach(x => totalPrice += x.Price);
			return Json(totalPrice);
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