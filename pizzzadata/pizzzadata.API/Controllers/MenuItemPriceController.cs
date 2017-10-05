using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pizzzadata.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pizzzadata.API.Controllers
{
    [Produces("application/json")]
    [Route("pizzzadata/api/[controller]")]
    public class MenuItemPriceController : Controller
    {
        private readonly PizzzaDatabaseContext _context;

        public MenuItemPriceController (PizzzaDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet("{menuId=1}/{sizeId=1}")]
        public IActionResult Get(int menuId, int sizeId)
        {
            var menuItemPrice = _context.MenuItemPrice.Where(z => z.MenuId == menuId).FirstOrDefault(y => y.SizeId == sizeId);

            return new ObjectResult(menuItemPrice.Price);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
