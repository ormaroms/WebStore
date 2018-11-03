using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class ItemController : Controller
    {
        private WebStoreContext db = new WebStoreContext();

        [HttpPost]
        public ActionResult AddItem(Item item, string actionName)
        {
            if (Session["UserOrder"] != null)
            {
                List<Item> myOrders = (List<Item>)Session["UserOrder"];
                myOrders.Add(item);
                Session["UserOrder"] = myOrders;
            }
            else
            {
                Session["UserOrder"] = new List<Item> { item };
            }
            return RedirectToAction(actionName);
        }

        [HttpPost]
        public ActionResult DelItem(Item item, string actionName)
        {
            var itemToDelete = db.Items.Where(x => x.ItemID == item.ItemID).FirstOrDefault();
            itemToDelete.IsDeleted = true;
            db.SaveChanges();

            return RedirectToAction(actionName);
        }

        public ActionResult AllMenItems(string brand, int? minPrice, int? maxPrice)
		{
			return View("ItemsView", FilterData("Men", null, brand, minPrice, maxPrice));

			//               var allItems = db.Items.Where(x => x.Gender == "Men");
			////               GroupBy(x => x.ItemID).Select(x => x.FirstOrDefault());

			//               return View("ItemsView",allItems.ToList()); 
		}

		public ActionResult AllWomenItems(string brand, int? minPrice, int? maxPrice)
		{
			return View("ItemsView", FilterData("Women", null, brand, minPrice, maxPrice));
		}

		public ActionResult AllItems(string brand, int? minPrice, int? maxPrice)
		{
			return View("ItemsView", FilterData(null, null, brand, minPrice, maxPrice));
		}

		public ActionResult AllPantsItems(string brand, int? minPrice, int? maxPrice)
		{
			return View("ItemsView", FilterData(null, 1, brand, minPrice, maxPrice));
		}

		public ActionResult AllShoesItems(string brand, int? minPrice, int? maxPrice)
		{ 
			return View("ItemsView", FilterData(null, 2, brand, minPrice, maxPrice));
		}

	public ActionResult AllShirtsItems(string brand, int? minPrice, int? maxPrice)
	{
		return View("ItemsView", FilterData(null, 3, brand, minPrice, maxPrice));
	}

	public ActionResult GetMenPants(string brand, int? minPrice, int? maxPrice)
	{
		return View("ItemsView", FilterData("Men", 1, brand, minPrice, maxPrice));
	}

	public ActionResult GetWomenPants(string brand, int? minPrice, int? maxPrice)
	{
		return View("ItemsView", FilterData("Women", 1, brand, minPrice, maxPrice));
	}

	public ActionResult GetWomenShoes(string brand, int? minPrice, int? maxPrice)
	{
		return View("ItemsView", FilterData("Women", 2, brand, minPrice, maxPrice));
	}

	public ActionResult GetMenShoes(string brand, int? minPrice, int? maxPrice)
	{
		return View("ItemsView", FilterData("Men", 2, brand, minPrice, maxPrice));
	}

	public ActionResult GetWomenShirts(string brand, int? minPrice, int? maxPrice)
	{
		return View("ItemsView", FilterData("Women", 3, brand, minPrice, maxPrice));
	}

	public ActionResult GetMenShirts(string brand, int? minPrice, int? maxPrice)
	{
		return View("ItemsView", FilterData("Men", 3, brand, minPrice, maxPrice));
	}

	private List<Item> FilterData(string gender, int? itemType, string brand, int? minPrice, int? maxPrice)
	{
        var allItems = db.Items.Where(x => true && !x.IsDeleted);
        if (gender != null)
		{
			allItems = allItems.Where(x => x.Gender == gender);
		}

		if (itemType.HasValue)
		{
			allItems = allItems.Where(x => x.ItemTypeId == itemType);
		}

		if (brand != null)
		{
			allItems = allItems.Where(x => x.Brand.Contains(brand));
		}

		if (minPrice.HasValue)
		{
			allItems = allItems.Where(x => x.Price > minPrice);
		}

		if (maxPrice.HasValue)
		{
			allItems = allItems.Where(x => x.Price < maxPrice);
		}

		return allItems.ToList();
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