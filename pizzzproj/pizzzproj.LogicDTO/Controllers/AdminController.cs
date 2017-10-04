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
    [Route("api/Admin")]
    public class AdminController : Controller
    {
        // GET: api/Admin
        /*
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET: api/Admin/5
        [HttpGet]
        public Admin Get(int id)
        {
            HttpClient httpClient = new HttpClient();

            var res = httpClient.GetAsync("http://localhost:58080/api/getadmin/" + id).GetAwaiter().GetResult();

            if(res.IsSuccessStatusCode)
            {
                var json = res.Content.ReadAsStringAsync().Result;
                var driver = JsonConvert.DeserializeObject<Admin>(json);
                Response.StatusCode = (int)HttpStatusCode.OK;
                return driver;
            }
            return null;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            HttpClient httpClient = new HttpClient();
            var res = httpClient.DeleteAsync("Achintya's local host/api/delete" + id).GetAwaiter().GetResult();

            if(res.IsSuccessStatusCode)
            {
                Response.StatusCode = (int)HttpStatusCode.OK;
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }

        [HttpPut]
        public void NewPricePut([FromBody]Item item, decimal newPrice)
        {
            item.ItemPrice = newPrice;
            HttpClient adminClient = new HttpClient();
            var oy = JsonConvert.SerializeObject(item);
            var body = new StringContent(oy, Encoding.UTF8, "application/json");
            var res = adminClient.PutAsync("http://localhost:58080/api/getmenu/", body).GetAwaiter().GetResult();

            if (res.IsSuccessStatusCode)
            {
                Response.StatusCode = (int)HttpStatusCode.Created;
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }

        // POST: api/Admin
        [HttpPut]
        public void NewNamePut([FromBody]Item item, string newName)
        {
            item.ItemName = newName;
            HttpClient adminClient = new HttpClient();
            var oy = JsonConvert.SerializeObject(item);
            var body = new StringContent(oy, Encoding.UTF8, "application/json");
            var res = adminClient.PutAsync("http://localhost:58080/api/getmenu/", body).GetAwaiter().GetResult();

            if(res.IsSuccessStatusCode)
            {
                Response.StatusCode = (int)HttpStatusCode.Created;
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }

        [HttpPost]
        public void NewItemPost([FromBody]Item item)
        {
            HttpClient pizzclient = new HttpClient();
            var yo = JsonConvert.SerializeObject(item);
            var body = new StringContent(yo, Encoding.UTF8, "application/json");
            var res = pizzclient.PostAsync("http://localhost:58080/api/TBD/", body).GetAwaiter().GetResult();

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
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void ItemDelete(int id, [FromBody] Item item)
        {
            //item.ItemId = id;
            HttpClient httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(id);
            var body = new StringContent(json, Encoding.UTF8, "application/json");
            var res = httpClient.DeleteAsync("http://localhost:58080/api/itemdelete/{0}" + id).GetAwaiter().GetResult();
        }        
    }
}
