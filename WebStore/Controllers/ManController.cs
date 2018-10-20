using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class ManController : Controller
    {
        private WebStoreContext db = new WebStoreContext();

        public ActionResult Shoes() {
            var shoes = db.Shoes.Where(x => x.Gender == "Men");

            // working query 
            // "select ItemID, Max(ImgPath), Max(Price), Max(Color), Max(Brand)
            // from[dbo].Shoes where Gender = 'Men' group by ItemID"


            return View(shoes.ToList());
        }

        public ActionResult Pants()
        {
            var pants = db.Pants.Where(x => x.Gender == "Men");
            return View(pants.ToList());
        }
    }
}