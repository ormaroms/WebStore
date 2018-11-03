using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStore.Controllers
{
    public class UserSuggestionsController : Controller
    {
        // GET: UserSuggestions
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult PredictUserSuggestions()
        {
            //int userId =n
            return null;
        }
    }
}