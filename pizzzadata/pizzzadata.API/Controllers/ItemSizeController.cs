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
    public class ItemSizeController : Controller
    {
        private readonly PizzzaDatabaseContext _context;

        public ItemSizeController(PizzzaDatabaseContext context)
        {
            _context = context;
        }

        // GET pizzzadata/api/itemsize
        [HttpGet]
        public List<ItemSize> Get()
        {
            return _context.ItemSize.ToList();
        }

        // GET pizzzadata/api/itemsize/sizeId
        [HttpGet("{sizeId=1}")]
        public ItemSize Get(int sizeId)
        {
            return _context.ItemSize.FirstOrDefault(z => z.SizeId == sizeId);
        }

        // POST pizzzadata/api/itemsize
        [HttpPost]
        public void Post([FromBody]Item newMenuItem)
        {
            ItemSize addItemSize = new ItemSize
            {
                Size = newMenuItem.Size
            };
            _context.ItemSize.Add(addItemSize);
            _context.SaveChanges();
        }

        // PUT pizzzadata/api/itemsize
        [HttpPut]
        public void Put(string newSize, [FromBody]Item updatedMenuItem)
        {
            _context.ItemSize.FirstOrDefault(z => z.Size == updatedMenuItem.Size).Size = newSize;
            _context.SaveChanges();
        }

        // DELETE pizzzadata/api/itemsize
        [HttpDelete]
        public void Delete([FromBody]Item deletedMenuItem)
        {
            var sizeItem = _context.ItemSize.FirstOrDefault(z => z.Size == deletedMenuItem.Size);
            _context.ItemSize.Remove(sizeItem);
            _context.SaveChanges();
        }
    }
}