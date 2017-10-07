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
    public class MenuItemController : Controller
    {
        private readonly PizzzaDatabaseContext _context;

        public MenuItemController(PizzzaDatabaseContext context)
        {
            _context = context;
        }

        // GET pizzzadata/api/menuitem/5
        [HttpGet("{itemId=1}")]
        public IActionResult Get(int itemId)
        {
            var menuItem = _context.MenuItem.FirstOrDefault(z => z.MenuId == itemId);

            return new ObjectResult(menuItem.Item);
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
