using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pizzzadata.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pizzzadata.API.Controllers
{
    [Route("api/[controller]")]
    public class GetMenuController : Controller
    {
        private readonly PizzzaDatabaseContext _context;

        public GetMenuController(PizzzaDatabaseContext context)
        {
            _context = context;
        }

        // GET api/getmenu
        [HttpGet]
        public IEnumerable<MenuItemPrice> Get()
        {
            var fullMenu = _context.MenuItemPrice;

            foreach (var menuItem in fullMenu)
            {
                menuItem.Menu = _context.MenuItem.FirstOrDefault(z => z.MenuId == menuItem.MenuId);
                menuItem.Size = _context.ItemSize.FirstOrDefault(y => y.SizeId == menuItem.SizeId);
            }
            return new List<MenuItemPrice> (_context.MenuItemPrice.ToList());
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
