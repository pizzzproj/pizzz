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
    [Route("Item/[controller]")]
    public class ItemController : Controller
    {

        private string _route = "http://ec2-34-207-116-9.compute-1.amazonaws.com/";
        /*
        [HttpPost]
        public void NewItemPost([FromBody]Item item)
        {
            HttpClient pizzclient = new HttpClient();
            var yo = JsonConvert.SerializeObject(item);
            var body = new StringContent(yo, Encoding.UTF8, "application/json");
            var res = pizzclient.PostAsync("", body).GetAwaiter().GetResult();

            if(res.IsSuccessStatusCode)
            {
                Response.StatusCode = (int)HttpStatusCode.Created;
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }*/


        //[HttpGet]
        //public decimal PizzaGetPrice(int i)
        //{
        //    HttpClient pizzclient = new HttpClient();

        //    var res = pizzclient.GetAsync(_route + i).GetAwaiter().GetResult();

        //    if(res.IsSuccessStatusCode)
        //    {
        //        var json = res.Content.ReadAsStringAsync().Result;
        //        var driver = JsonConvert.DeserializeObject<decimal>(json);
        //        Response.StatusCode = (int)HttpStatusCode.OK;
        //        return driver;
        //    }
        //    return 0;
        //}

        // pizzza/item/getmenu
        [HttpGet]
        public List<Item> GetMenu()
        {
            HttpClient orderclient = new HttpClient();

            var res = orderclient.GetAsync(_route + "data/pizzzadata/api/menu").GetAwaiter().GetResult();

            if (res.IsSuccessStatusCode)
            {
                var json = res.Content.ReadAsStringAsync().Result;
                var driver = JsonConvert.DeserializeObject<List<Item>>(json);
                Response.StatusCode = (int)HttpStatusCode.OK;
                return driver;
            }
            return null;
        }

//        [HttpGet]
//        public Item GetItem(int id)
//        {
//            HttpClient httpClient = new HttpClient();
//            var res = httpClient.GetAsync(_route + id).GetAwaiter().GetResult();

//            if(res.IsSuccessStatusCode)
//            {
//                var json = res.Content.ReadAsStringAsync().Result;
//                var driver = JsonConvert.DeserializeObject<Item>(json);
//                Response.StatusCode = (int)HttpStatusCode.OK;
//                return driver;
//            }
//            return null;
//        }



//        // PUT: api/Item/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody]string value)
//        {
//        }
        
//        // DELETE: api/ApiWithActions/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
    }
}