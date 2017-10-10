using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using pizzzadata.API.Models;
using pizzzadata.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pizzzadata.API.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("pizzzadata/api/[controller]")]
    public class MenuItemController : Controller
    {
        private readonly PizzzaDatabaseContext _context;

        public MenuItemController(PizzzaDatabaseContext context)
        {
            _context = context;
        }

        // GET pizzzadata/api/menuitem/itemId
        [HttpGet("{itemId=1}")]
        public IActionResult Get(int itemId)
        {
            var menuItem = _context.MenuItem.FirstOrDefault(z => z.MenuId == itemId);
            var wholeitem = _context.MenuItemPrice.FirstOrDefault(y => y.MenuId == menuItem.MenuId);

            return new ObjectResult(wholeitem);
           
        }

        // POST api/values
        [HttpPost]
        public void Post(string newMenuItemString)
        {
            Console.WriteLine(newMenuItemString);
            //MenuItem addMenuItem = new MenuItem
            //{
            //    Item = newMenuItem.Name
            //};
            //_context.MenuItem.Add(addMenuItem);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
