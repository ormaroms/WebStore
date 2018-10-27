using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;
using Newtonsoft.Json;

namespace WebStore.Controllers
{
    public class GraphController : Controller
    {
        private WebStoreContext db = new WebStoreContext();

        // GET: Graph
        public ActionResult Graph()
        {
            return View();
        }

        public string GetData()
        {
            var results = db.Orders
        .Join(db.Item,
        o => o.ItemID,
        i => i.ItemID,
        (o, i) => new
        {
            Brand = i.Brand,
            ItemTypeId = i.ItemTypeId
        }).Join(db.ItemType,
                    r => r.ItemTypeId,
                    i => i.ItemTypeId,
                    (r, i) => new
                    {
                        Brand = r.Brand,
                        ItemTypeName = i.name,
                        ItemTypeId = i.ItemTypeId
                    }).GroupBy(x => new { x.Brand, x.ItemTypeId }).ToList();

            return JsonConvert.SerializeObject(results);
        }



    }
}



//select brand, ItemTypeId, count(ItemTypeId)
//from(
//select items.Brand , items.ItemTypeId
//from orders
//inner join items on orders.ItemID = items.ItemID) f
//group by brand, ItemTypeId