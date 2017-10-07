using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pizzzproj.LogicDTO.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net;

namespace pizzzproj.LogicDTO.Controllers
{
    [Produces("application/json")]
    [Route("Admin/[Controller]")]
    public class AdminController : Controller
    {
        private string _route = "ec2-34-207-116-9.compute-1.amazonaws.com/";

        // GET: pizzza/Admin/get/5
        [HttpGet]
        public Admin GetAdmin(int id)
        {
            HttpClient httpClient = new HttpClient();

            var res = httpClient.GetAsync(_route + id).GetAwaiter().GetResult();

            if(res.IsSuccessStatusCode)
            {
                var json = res.Content.ReadAsStringAsync().Result;
                var driver = JsonConvert.DeserializeObject<Admin>(json);
                Response.StatusCode = (int)HttpStatusCode.OK;
                return driver;
            }
            return null;
        }

        // DELETE: pizzza/Admin/delete/5
        [HttpDelete]
        public void Delete(int id)
        {
            HttpClient httpClient = new HttpClient();
            var res = httpClient.DeleteAsync(_route + id).GetAwaiter().GetResult();

            if(res.IsSuccessStatusCode)
            {
                Response.StatusCode = (int)HttpStatusCode.OK;
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }

        // PUT: pizzza/Admin/NewPricePut/{item}/5
        [HttpPut]
        public void NewPricePut([FromBody]Item item, decimal newPrice)
        {
            item.ItemPrice = newPrice;
            HttpClient adminClient = new HttpClient();
            var oy = JsonConvert.SerializeObject(item);
            var body = new StringContent(oy, Encoding.UTF8, "application/json");
            var res = adminClient.PutAsync(_route, body).GetAwaiter().GetResult();

            if (res.IsSuccessStatusCode)
            {
                Response.StatusCode = (int)HttpStatusCode.Created;
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }

        // Put: pizzza/Admin/NewNamePut/{item}/{name}
        [HttpPut]
        public void NewNamePut([FromBody]Item item, string newName)
        {
            item.ItemName = newName;
            HttpClient adminClient = new HttpClient();
            var oy = JsonConvert.SerializeObject(item);
            var body = new StringContent(oy, Encoding.UTF8, "application/json");
            var res = adminClient.PutAsync(_route, body).GetAwaiter().GetResult();

            if(res.IsSuccessStatusCode)
            {
                Response.StatusCode = (int)HttpStatusCode.Created;
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }

        // POST: pizzza/Admin/NewItemPost/{item}
        [HttpPost]
        public void NewItemPost([FromBody]Item item)
        {
            HttpClient pizzclient = new HttpClient();
            var yo = JsonConvert.SerializeObject(item);
            var body = new StringContent(yo, Encoding.UTF8, "application/json");
            var res = pizzclient.PostAsync(_route, body).GetAwaiter().GetResult();

            if (res.IsSuccessStatusCode)
            {
                Response.StatusCode = (int)HttpStatusCode.Created;
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }

        // PUT: api/Admin/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: pizzza/Admin/ItemDelete/5/{item}
        [HttpDelete("{id}")]
        public void ItemDelete(int id, [FromBody] Item item)
        {
            //item.ItemId = id;
            HttpClient httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(id);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            var res = httpClient.DeleteAsync(_route + id).GetAwaiter().GetResult();
        }        
    }
}
