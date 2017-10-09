using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pizzzUI.Models;

namespace pizzzUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

           // var courses = _context.Courses
               // .AsNoTracking();
           // return View(await courses.ToListAsync());

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Welcome to PiZZZa!";

            return View();
        }

        public IActionResult DeliveryOrCarry()
        {
            return View();
        }


        public IActionResult DeliveryAddress()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }



        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
