using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using pizzzproj.LogicDTO.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

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
        /*
        [HttpPost]
        public void PizzaPost([FromBody]int id)
        {
            HttpClient pizzclient = new HttpClient();
            var yo = JsonConvert.SerializeObject(id);
            var body = new StringContent(yo, Encoding.UTF32, "application/json");
            var res = pizzclient.GetAsync("http://localhost:58080/api/menuitemprice/", body).GetAwaiter().GetResult();

            if(res.IsSuccessStatusCode)
            {
                Response.StatusCode = (int)HttpStatusCode.Created;
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }
        */

        [HttpGet]
        public decimal PizzaGetPrice(int i)
        {
            HttpClient pizzclient = new HttpClient();

            var res = pizzclient.GetAsync("http://localhost:58080/api/menuitemprice/" + i).GetAwaiter().GetResult();

            if(res.IsSuccessStatusCode)
            {
                var json = res.Content.ReadAsStringAsync().Result;
                var driver = JsonConvert.DeserializeObject<decimal>(json);
                Response.StatusCode = (int)HttpStatusCode.OK;
                return driver;
            }
            return 0;
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
