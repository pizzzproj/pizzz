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
using Microsoft.AspNetCore.Authorization;
//---------------------------------------------MENU-------------------------------------------------
namespace pizzzproj.LogicDTO.Controllers
{
    [Produces("application/json")]
    [Route("Item/[controller]")]
    public class ItemController : Controller
    {

        private string _route = "http://ec2-34-207-116-9.compute-1.amazonaws.com/";

       // [AllowAnonymous]
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
    }
}