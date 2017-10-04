using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pizzzadata.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pizzzadata.API.Controllers
{
    [Produces("application/json")]
    [Route("pizzzadata/api/[controller]")]
    public class MenuItemPriceController : Controller
    {
        private readonly PizzzaDatabaseContext _context;

        public MenuItemPriceController(PizzzaDatabaseContext context)
        {
            _context = context;
        }

        // GET api/menuitemprice
        [HttpGet("{menuId=1}/{sizeId=1}")]
        public IActionResult Get(int menuId, int sizeId)
        {
            var menuItemPrice = _context.MenuItemPrice.Where(z => z.MenuId == menuId).FirstOrDefault(y => y.SizeId == sizeId);

            return new ObjectResult(menuItemPrice.Price);
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
