using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pizzzproj.LogicDTO.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using System.Text;
//----------------------------------------------ITEM-------------------------------------------------
namespace pizzzproj.LogicDTO.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public abstract class BaseController : Controller
    {

        private string _route = "http://ec2-34-207-116-9.compute-1.amazonaws.com/";


        [HttpGet("{id=1}")]
        public Item GetItem(int id)
        {
            HttpClient orderclient = new HttpClient();

            var res = orderclient.GetAsync(_route + "data/pizzzadata/api/menuitem/" + id).GetAwaiter().GetResult();

            if (res.IsSuccessStatusCode)
            {
                var json = res.Content.ReadAsStringAsync().Result;
                var driver = JsonConvert.DeserializeObject<Item>(json);
                Response.StatusCode = (int)HttpStatusCode.OK;
                return driver;
            }
            return null;
        }

        [HttpPost]
        public void CreateItemPost([FromBody]Item item)
        {
            HttpClient pizzclient = new HttpClient();
            var yo = JsonConvert.SerializeObject(item);
            var body = new StringContent(yo, Encoding.UTF8, "application/json");
            var res = pizzclient.PostAsync(_route + "data/pizzzadata/api/menuitem/", body).GetAwaiter().GetResult();

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
        public void DeleteItem(int id)
        {
            HttpClient httpClient = new HttpClient();
            var res = httpClient.DeleteAsync(_route + "data/pizzzadata/api/menuitem/" + id).GetAwaiter().GetResult();

            if (res.IsSuccessStatusCode)
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