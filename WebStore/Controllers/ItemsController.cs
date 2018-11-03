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

        public ActionResult Index()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(int type, double price, string color, string brand, string gender, HttpPostedFileBase image)
        {
            string path = Path.Combine(Server.MapPath("~/Images"),
                            Path.GetFileName(image.FileName));
            image.SaveAs(path);
            Item item = new Item(type, price, color, brand, gender, "~/Images/" + image.FileName);
            db.Items.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


    }
}