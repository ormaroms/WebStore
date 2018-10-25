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
		// GET: Map
		public ActionResult Index()
		{
			return View();
		}

		public string GetPickUpPoints()
		{
			
			using (WebStoreContext db = new WebStoreContext())
			{
				return JsonConvert.SerializeObject(db.PickUpPoints);
			}
		}

	}
}