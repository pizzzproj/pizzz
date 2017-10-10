using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pizzzadata.API.Models;
using pizzzadata.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pizzzadata.API.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("pizzzadata/api/[controller]")]
    public class MenuItemPriceController : Controller
    {
        private readonly PizzzaDatabaseContext _context;

        public MenuItemPriceController (PizzzaDatabaseContext context)
        {
            _context = context;
        }

        // GET: pizzzadata/api/menuitemprice/menuId/sizeId
        [HttpGet("{menuId=1}/{sizeId=1}")]
        public MenuItemPrice Get(int menuId, int sizeId)
        {
            return _context.MenuItemPrice.Where(z => z.MenuId == menuId).FirstOrDefault(y => y.SizeId == sizeId);
        }

        // POST pizzzadata/api/menuitemprice
        [HttpPost]
        public void Post([FromBody]Item newMenuItem)
        {
            MenuItemPrice addMenuItem = new MenuItemPrice
            {
                MenuId = _context.MenuItem.Single(z => z.Item == newMenuItem.ItemName).MenuId,
                SizeId = _context.ItemSize.FirstOrDefault(z => z.Size == newMenuItem.Size).SizeId,
                Price = newMenuItem.Price
            };
            _context.MenuItemPrice.Add(addMenuItem);
            _context.SaveChanges();
        }

        // PUT pizzzadata/api/menuitemprice
        [HttpPut]
        public void Put([FromBody]Item updatedMenuItem)
        {
            _context.MenuItemPrice.Where(z => z.Menu.Item == updatedMenuItem.ItemName)
                .FirstOrDefault(y => y.Size.Size == updatedMenuItem.Size).Price
                = updatedMenuItem.Price;
            _context.SaveChanges();
        }

        // DELETE pizzzadata/api/menuitemprice
        [HttpDelete]
        public void Delete([FromBody]Item deletedMenuItem)
        {
            var menuItemPrice = _context.MenuItemPrice.Where(z => z.Menu.Item == deletedMenuItem.ItemName)
                .FirstOrDefault(y => y.Size.Size == deletedMenuItem.Size);
            _context.MenuItemPrice.Remove(menuItemPrice);
            _context.SaveChanges();
        }
    }
}
