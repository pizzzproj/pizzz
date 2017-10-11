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
            try
            {
                return _context.ItemSize.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // GET pizzzadata/api/itemsize/sizeId
        [HttpGet("{sizeId=1}")]
        public ItemSize Get(int sizeId)
        {
            try
            {
                return _context.ItemSize.FirstOrDefault(z => z.SizeId == sizeId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // POST pizzzadata/api/itemsize
        [HttpPost]
        public void Post([FromBody]Item newMenuItem)
        {
            try
            {
                ItemSize addItemSize = new ItemSize
                {
                    Size = newMenuItem.Size
                };
                _context.ItemSize.Add(addItemSize);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // PUT pizzzadata/api/itemsize
        [HttpPut]
        public void Put(string newSize, [FromBody]Item updatedMenuItem)
        {
            try
            {
                _context.ItemSize.FirstOrDefault(z => z.Size == updatedMenuItem.Size).Size = newSize;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // DELETE pizzzadata/api/itemsize
        [HttpDelete]
        public void Delete([FromBody]Item deletedMenuItem)
        {
            try
            {
                var sizeItem = _context.ItemSize.FirstOrDefault(z => z.Size == deletedMenuItem.Size);
                _context.ItemSize.Remove(sizeItem);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}