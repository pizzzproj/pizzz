using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using pizzzproj.LogicDTO.Models;

namespace pizzzproj.LogicDTO.Controllers
{
    [Produces("application/json")]
    [Route("api/Item")]
    public class ItemController : Controller
    {
        // GET: api/Item
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            Response.StatusCode = (int)HttpStatusCode.OK;

            return new List<Item>()
            {
                new Item() { ItemId = 1, ItemName = "Pizza", ItemSize = "Large"},
                new Item() { ItemId = 2, ItemName = "Beer", ItemSize = "XL"},
                new Item() { ItemId = 3, ItemName = "Wings", ItemSize = "Family"}
            };
        }

        // GET: api/Item/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Item
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Item/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}