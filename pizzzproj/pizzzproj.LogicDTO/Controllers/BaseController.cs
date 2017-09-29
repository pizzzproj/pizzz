using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace pizzzproj.LogicDTO.Controllers
{
    [Produces("application/json")]
    [Route("api/Base")]
    public abstract class BaseController : Controller
    {
        [HttpGet]
        public virtual IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

       
        [HttpGet("{id}")]
        public virtual string Get(int id)
        {
            return "value";
        }

        
        [HttpPost]
        public virtual void Post([FromBody]string value)
        {
        }

     
        [HttpPut("{id}")]
        public virtual void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public virtual void Delete(int id)
        {
        }
    }
}