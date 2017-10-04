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
    public class ItemSizesController : Controller
    {
        private readonly PizzzaDatabaseContext _context;

        public ItemSizesController(PizzzaDatabaseContext context)
        {
            _context = context;
        }

        // GET api/itemsizes/id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var itemSize = _context.ItemSize.FirstOrDefault(z => z.SizeId == id);

            return new ObjectResult(itemSize);
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
