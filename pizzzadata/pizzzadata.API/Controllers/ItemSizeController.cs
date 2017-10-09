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
    public class ItemSizeController : Controller
    {
        private readonly PizzzaDatabaseContext _context;

        public ItemSizeController(PizzzaDatabaseContext context)
        {
            _context = context;
        }

        // GET pizzzadata/api/itemsize/sizeId
        [HttpGet("{sizeId=1}")]
        public IActionResult Get(int sizeId)
        {
            var menuItem = _context.ItemSize.FirstOrDefault(z => z.SizeId == sizeId);

            return new ObjectResult(menuItem.Size);
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
