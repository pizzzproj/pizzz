using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pizzzadata.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pizzzadata.API.Controllers
{
    [Produces("application/json")]
    [Route("pizzzadata/api/[controller]")]
    public class MenuItemsController : Controller
    {
        private readonly PizzzaDatabaseContext _context;

        public MenuItemsController(PizzzaDatabaseContext context)
        {
            _context = context;
        }

        // GET api/menuitems/id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var menuItem = _context.MenuItem.FirstOrDefault(z => z.MenuId == id);

            return new ObjectResult(menuItem);
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
