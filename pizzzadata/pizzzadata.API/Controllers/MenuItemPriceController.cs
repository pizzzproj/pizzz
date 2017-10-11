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
            try
            {
                return _context.MenuItemPrice.Where(z => z.MenuId == menuId).FirstOrDefault(y => y.SizeId == sizeId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // POST pizzzadata/api/menuitemprice
        [HttpPost]
        public void Post([FromBody]Item newMenuItem)
        {
            try
            {
                MenuItemPrice addMenuItem = new MenuItemPrice
                {
                    MenuId = _context.MenuItem.Single(z => z.Item == newMenuItem.ItemName).MenuId,
                    SizeId = _context.ItemSize.FirstOrDefault(z => z.Size == newMenuItem.ItemSize).SizeId,
                    Price = newMenuItem.ItemPrice
                };
                _context.MenuItemPrice.Add(addMenuItem);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // PUT pizzzadata/api/menuitemprice
        [HttpPut]
        public void Put([FromBody]Item updatedMenuItem)
        {
            try
            {
                _context.MenuItemPrice.Where(z => z.Menu.Item == updatedMenuItem.ItemName)
                    .FirstOrDefault(y => y.Size.Size == updatedMenuItem.ItemSize).Price
                    = updatedMenuItem.ItemPrice;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // DELETE pizzzadata/api/menuitemprice
        [HttpDelete]
        public void Delete([FromBody]Item deletedMenuItem)
        {
            try
            {
                var menuItemPrice = _context.MenuItemPrice.Where(z => z.Menu.Item == deletedMenuItem.ItemName)
                    .FirstOrDefault(y => y.Size.Size == deletedMenuItem.ItemSize);
                _context.MenuItemPrice.Remove(menuItemPrice);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
