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
//----------------------------------------------------------------ADMIN------------------------------
namespace pizzzproj.LogicDTO.Controllers
{
    [Produces("application/json")]
    [Route("Admin/[Controller]")]
    public class AdminController : Controller
    {
        private string _route = "http://ec2-34-207-116-9.compute-1.amazonaws.com/";
        
        [HttpGet("{id=1}")]
        public Admin GetAdmin(int id)
        {
            HttpClient httpClient = new HttpClient();

            var res = httpClient.GetAsync(_route + "data/pizzzadata/api/admin/" + id).GetAwaiter().GetResult();

            if(res.IsSuccessStatusCode)
            {
                var json = res.Content.ReadAsStringAsync().Result;
                var driver = JsonConvert.DeserializeObject<Admin>(json);
                Response.StatusCode = (int)HttpStatusCode.OK;
                return driver;
            }
            return null;
        }
      
        [HttpPost]
        public void CreateAdmin([FromBody]Admin admin)
        {
            HttpClient pizzclient = new HttpClient();
            var yo = JsonConvert.SerializeObject(admin);
            var body = new StringContent(yo, Encoding.UTF8, "application/json");
            var res = pizzclient.PostAsync(_route + "data/pizzzadata/api/", body).GetAwaiter().GetResult();

            if (res.IsSuccessStatusCode)
            {
                Response.StatusCode = (int)HttpStatusCode.Created;
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }
    
        [HttpPut]
        public void NewNamePut([FromBody]Item item)
        {
            HttpClient adminClient = new HttpClient();
            var oy = JsonConvert.SerializeObject(item);
            var body = new StringContent(oy, Encoding.UTF8, "application/json");
            var res = adminClient.PutAsync(_route + "data/pizzzadata/api/menuitem/" + item.ItemId, body).GetAwaiter().GetResult();

            if (res.IsSuccessStatusCode)
            {
                Response.StatusCode = (int)HttpStatusCode.Created;
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }

        [HttpDelete("{id=1}")]
        public void DeleteAdmin(int id)
        {
            HttpClient httpClient = new HttpClient();
            var res = httpClient.DeleteAsync(_route + "data/pizzzadata/api/admin/" + id).GetAwaiter().GetResult();

            if(res.IsSuccessStatusCode)
            {
                Response.StatusCode = (int)HttpStatusCode.OK;
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }     
    }
}
