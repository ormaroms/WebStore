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
            var shoes = db.Shoes.Where(x => x.Gender == "Men").
                GroupBy(x => x.ItemID).Select(x => x.FirstOrDefault());

            return View(shoes.ToList());
        }

        public ActionResult Pants()
        {
            var pants = db.Pants.Where(x => x.Gender == "Men").
            GroupBy(x => x.ItemID).Select(x => x.FirstOrDefault());
            return View(pants.ToList());
        }
    }
}