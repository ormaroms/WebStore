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

        public ActionResult AllMenItems()
        {
            using (WebStoreContext db = new WebStoreContext())
            {
                var allItems = db.Items.Where(x => x.Gender == "Men");
 //               GroupBy(x => x.ItemID).Select(x => x.FirstOrDefault());

                return View("ItemsView",allItems.ToList());
            }   
        }

        public ActionResult AllWomenItems()
        {
            using (WebStoreContext db = new WebStoreContext())
            {
                var allItems = db.Items.Where(x => x.Gender == "Women");

                return View("ItemsView", allItems.ToList());
            }
        }

        public ActionResult AllItems()
        {
            using (WebStoreContext db = new WebStoreContext())
            {
                var allItems = db.Items;

                return View("ItemsView", allItems.ToList());
            }
        }

        public ActionResult AllPantsItems()
        {
            using (WebStoreContext db = new WebStoreContext())
            {
                var allPants = db.Items.Where(x => x.ItemTypeId == 1);

                return View("ItemsView", allPants.ToList());
            }
        }

        public ActionResult AllShoesItems()
        {
            using (WebStoreContext db = new WebStoreContext())
            {
                var allShoes = db.Items.Where(x => x.ItemTypeId == 2);

                return View("ItemsView", allShoes.ToList());
            }
        }

        public ActionResult AllShirtsItems()
        {
            using (WebStoreContext db = new WebStoreContext())
            {
                var allShirts = db.Items.Where(x => x.ItemTypeId == 3);

                return View("ItemsView", allShirts.ToList());
            }
        }

        public ActionResult GetMenPants()
        {
            using (WebStoreContext db = new WebStoreContext())
            {
                var allManPants = db.Items.Where(x => x.Gender == "Men" && x.ItemTypeId == 1);

                return View("ItemsView", allManPants.ToList());
            }
        }

        public ActionResult GetWomenPants()
        {
            using (WebStoreContext db = new WebStoreContext())
            {
                var allManPants = db.Items.Where(x => x.Gender == "Women" && x.ItemTypeId == 1);

                return View("ItemsView", allManPants.ToList());
            }
        }

        public ActionResult GetWomenShoes()
        {
            using (WebStoreContext db = new WebStoreContext())
            {
                var allWomenPants = db.Items.Where(x => x.Gender == "Women" && x.ItemTypeId == 2);

                return View("ItemsView", allWomenPants.ToList());
            }
        }

        public ActionResult GetMenShoes()
        {
            using (WebStoreContext db = new WebStoreContext())
            {
                var allMenPants = db.Items.Where(x => x.Gender == "Men" && x.ItemTypeId == 2);

                return View("ItemsView", allMenPants.ToList());
            }
        }

        public ActionResult GetWomenShirts()
        {
            using (WebStoreContext db = new WebStoreContext())
            {
                var allWomenShirts = db.Items.Where(x => x.Gender == "Women" && x.ItemTypeId == 3);

                return View("ItemsView", allWomenShirts.ToList());
            }
        }

        public ActionResult GetMenShirts()
        {
            using (WebStoreContext db = new WebStoreContext())
            {
                var allMenShirts = db.Items.Where(x => x.Gender == "Men" && x.ItemTypeId == 3);

                return View("ItemsView", allMenShirts.ToList());
            }
        }
    }
}