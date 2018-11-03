using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class ItemsController : Controller
    {
        private WebStoreContext db = new WebStoreContext();

        public ActionResult Index(Item item)
        {
            return View("Create", new List<Item>() {item });
        }

        [HttpPost]
        public ActionResult Create(int type, double price, string color, string brand, string gender, 
            bool isUpdate, int itemID, HttpPostedFileBase image)
        {
            if (isUpdate)
            {
                Item itemToUpdate = db.Items.First(x => x.ItemID == itemID);
                itemToUpdate.ItemTypeId = type;
                itemToUpdate.Price = price;
                itemToUpdate.Color = color;
                itemToUpdate.Brand = brand;
                itemToUpdate.Gender = gender;
            }
            else { 
                string path = Path.Combine(Server.MapPath("~/Images"),
                                Path.GetFileName(image.FileName));
                image.SaveAs(path);
                Item item = new Item(type, price, color, brand, gender, "~/Images/" + image.FileName);
                db.Items.Add(item);
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
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