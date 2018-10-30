using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class UsersController : Controller
    {
        private WebStoreContext db = new WebStoreContext();

        public ActionResult Index()
        {
            return View("Manage", db.Users.Where(x => !x.IsDeleted).ToList());
        }

        [HttpPost]
        public ActionResult Update(string userId, string userName, string password, string isAdmin)
        {
            User user = db.Users.Find(int.Parse(userId));
            user.UserName = userName;
            user.Password = password;
            user.IsAdmin = bool.Parse(isAdmin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(string userId)
        {
            User user = db.Users.Find(int.Parse(userId));
            user.IsDeleted = true;
            db.SaveChanges();
            return Json(new { Success = true });
        }

        [HttpPost]
        public ActionResult Create( string userName, string password, string isAdmin)
        {
            User user = new User( userName, password, bool.Parse(isAdmin));
            db.Users.Add(user);
            db.SaveChanges();
            return Json(new { Success = true });
        }
    }
}