using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class PickUpPointsController : Controller
    {
        private WebStoreContext db = new WebStoreContext();

        public ActionResult Index()
        {
            return View("Manage", db.PickUpPoints.Where(x => !x.IsDeleted).ToList());
        }

        [HttpPost]
        public ActionResult Update(string id, string name, string locationLongitude, string locationLatitude)
        {
            PickUpPoint pickUpPoint = db.PickUpPoints.Find(int.Parse(id));
            pickUpPoint.Name = name;
            pickUpPoint.LocationLongitude = double.Parse(locationLongitude);
            pickUpPoint.LocationLatitude = double.Parse(locationLatitude);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            PickUpPoint pickUpPoint = db.PickUpPoints.Find(int.Parse(id));
            pickUpPoint.IsDeleted = true;
            db.SaveChanges();
            return Json(new { Success = true });
        }

        [HttpPost]
        public ActionResult Create(string name, string locationLongitude, string locationLatitude)
        {
            PickUpPoint pickUpPoint = new PickUpPoint(name, double.Parse(locationLongitude), double.Parse(locationLatitude));
            db.PickUpPoints.Add(pickUpPoint);
            db.SaveChanges();
            return Json(new { Success = true });
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