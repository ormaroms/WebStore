using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class MapController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public string GetPickUpPoints()
        {
            List<PickUpPoint> pickUpPointsJson = new List<PickUpPoint>();

            using (WebStoreContext db = new WebStoreContext())
            {
                db.PickUpPoints.ToList().ForEach(point => pickUpPointsJson.
                    Add(point));
            }

            return JsonConvert.SerializeObject(pickUpPointsJson);
        }
    }
}