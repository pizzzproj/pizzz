using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pizzzUIMap.Controllers
{
    public class HomeController : Controller
    {
        //This action displays Maps information
        public ActionResult Index()
        {
            return View();
        }
        //GetAllLocation - for fetch all the location from database and show in the view
        //Shows all the locations in default map here.
        public JsonResult GetAllLocation()
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.Locations.OrderBy(a => a.Title).ToList();
                return new JsonResult { Data = v, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        //This method gets the markers info from database.
        public JsonResult GetMarkerData(int locationID)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                Location l = null;
                l = dc.Locations.Where(a => a.LocationID.Equals(locationID)).FirstOrDefault();
                return new JsonResult { Data = l, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
    }
}