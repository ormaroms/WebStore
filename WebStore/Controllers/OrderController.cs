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
                myOrders.RemoveAll(r => r.ItemID == itemID);
            }

            Session["UserOrder"] = myOrders;

            return RedirectToAction(actionName);
        }

		public ActionResult Checkout()
		{
			return View("Checkout", db.PickUpPoints.ToList());
		}

		public ActionResult SaveOrder(int pickupPoint)
		{
			Dictionary<int, Order> newOrderItems = new Dictionary<int, Order>();
			//int userId = (int)Session["UserID"];
			int userId = 3;

			List<Item> orderItems = (List<Item>)Session["UserOrder"];

			// Get Seqaunce
			int nextSeq = db.Sequences.Select(x => x.OrderID).ToList()[0];
			db.Sequences.Where(x => true).ToList()[0].OrderID = nextSeq + 1;

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

			Order newOrderRow2 = new Order();
			newOrderRow2.OrderID = 2;
			newOrderRow2.PickUpPointID = 1;
			newOrderRow2.UserID = 3;
			newOrderRow2.OrderDate = DateTime.Now;
			newOrderRow2.ItemID = 12;
			newOrderRow2.Quantity = 2;

			db.Orders.Add(newOrderRow2);
			db.SaveChanges();


			// Adding the rows to db
			//db.Orders.Add(newOrderItems.Values.ToList()[0]);
			//db.SaveChanges();

			newOrderItems.Values.ToList().ForEach(orderRow =>
			{
				//Order orderToInsert = new Order()
				//{
				//	OrderID = orderRow.OrderID,
				//	UserID = orderRow.UserID,
				//	OrderDate = DateTime.Now,
				//	ItemID = orderRow.ItemID,
				//	Quantity = orderRow.Quantity,
				//	PickUpPointID = orderRow.PickUpPointID
				//};

				Order orderToInsert = new Order()
				{
					OrderID = 5,
					UserID = 4,
					OrderDate = DateTime.Now,
					ItemID = 3,
					Quantity = 2,
					PickUpPointID = 2
				};

				db.Orders.Add(orderToInsert);
				db.SaveChanges();
			});


			return View();
		}

		[HttpPost]
		public ActionResult GetUserName()
		{
			//string name = db.Users.First(x => x.UserID == (int)Session["UserID"]).UserName;
			//string name = db.Users.Where(x => x.UserID == (int)Session["UserID"]).
			//	Select(x => x.UserName).ToList()[0];
			//int userId = (int)Session["UserID"];
			string name =
				(from usr in db.Users where usr.UserID == 3 select usr.UserName).ToList()[0];
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