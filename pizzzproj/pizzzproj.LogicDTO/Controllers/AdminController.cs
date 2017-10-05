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
    [Route("pizzza/Admin")]
    public class AdminController : Controller
    {

        // GET: pizzza/Admin/get/5
        [HttpGet]
        public Admin Get(int id)
        {
            HttpClient httpClient = new HttpClient();

            var res = httpClient.GetAsync("http://localhost:58080/pizzzadata/api/getadmin/" + id).GetAwaiter().GetResult();

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
            var res = httpClient.DeleteAsync("http://localhost:58080/pizzzadata/api/deleteadmin/" + id).GetAwaiter().GetResult();

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
            var res = adminClient.PutAsync("http://localhost:58080/pizzzadata/api/newpriceput/", body).GetAwaiter().GetResult();

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
            var res = adminClient.PutAsync("http://localhost:58080/pizzzadata/api/newnameput/", body).GetAwaiter().GetResult();

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
            var res = pizzclient.PostAsync("http://localhost:58080/pizzzadata/api/TBD/", body).GetAwaiter().GetResult();

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
            var res = httpClient.DeleteAsync("http://localhost:58080/pizzzadata/api/itemdelete/{0}" + id).GetAwaiter().GetResult();
        }        
    }
}
