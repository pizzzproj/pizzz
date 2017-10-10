using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pizzzproj.LogicDTO.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace pizzzproj.LogicDTO.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        private string _route = "http://ec2-34-207-116-9.compute-1.amazonaws.com/";



        //[Authorize(Roles = "Admin")]
        [HttpPut]
        public void NewPricePut([FromBody]Item item)
        {
            HttpClient adminClient = new HttpClient();
            var oy = JsonConvert.SerializeObject(item);
            var body = new StringContent(oy, Encoding.UTF8, "application/json");
            var res = adminClient.PutAsync(_route + "data/pizzzadata/api/menuitemprice/" + item.ItemId + "/" + item.ItemSize, body).GetAwaiter().GetResult();

            if (res.IsSuccessStatusCode)
            {
                Response.StatusCode = (int)HttpStatusCode.Created;
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }
    }
}
