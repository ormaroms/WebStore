using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class LoginController : Controller
    {

        private WebStoreContext db = new WebStoreContext();

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            var user = db.Users.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();

            if (user != null)
            {
                SignIn(userName, user.IsAdmin);
				Session["UserID"] = user.UserID;
                return Json(new { Success = true });
            }
            else
            {
                return new HttpStatusCodeResult(410, "Unable to find user.");
            }

        }

        [HttpGet]
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            Session["UserID"] = null;
            Session["UserOrder"] = null;
            return RedirectToAction("Index", "Home");
        }


        private void SignIn(string userName, bool isAdmin)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, userName));

            claims.Add(new Claim(ClaimTypes.Role, isAdmin ? "admin" : "user"));
            var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            AuthenticationManager.SignIn(id);
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