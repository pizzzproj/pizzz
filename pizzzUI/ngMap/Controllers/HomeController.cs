using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Reflection;

namespace ngMap.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllLocation()
        {
            using (pizzzaDatabaseEntities2 pde = new pizzzaDatabaseEntities2())
            {
                var v = pde.Locations.OrderBy(a => a.Title).ToList();
                return new JsonResult { Data = v, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public JsonResult GetMarkerInfo(int locationID)
        {
            using (pizzzaDatabaseEntities2 pde = new pizzzaDatabaseEntities2())
            {
                Location l = null;
                l = pde.Locations.Where(a => a.LocationID.Equals(locationID)).FirstOrDefault();
                return new JsonResult { Data = l, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

    }
}