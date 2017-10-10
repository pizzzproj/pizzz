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
    public class MenuController : Controller
    {
        private readonly PizzzaDatabaseContext _context;

        public MenuController(PizzzaDatabaseContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public List<Item> Get()
        {
            var fullMenuQuery = from a in _context.MenuItemPrice
                                join b in _context.MenuItem on a.MenuId equals b.MenuId
                                join c in _context.ItemSize on a.SizeId equals c.SizeId
                                select new Item
                                {
                                    ItemName = b.Item,
                                    Size = c.Size,
                                    Price = (decimal) a.Price
                                };
            List<Item> apiFullMenu = new List<Item> { };

            foreach (var item in fullMenuQuery)
            {
                apiFullMenu.Add(item);
            }
            return (apiFullMenu);
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
