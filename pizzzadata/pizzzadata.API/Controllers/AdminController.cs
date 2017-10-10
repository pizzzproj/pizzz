using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pizzzadata.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pizzzadata.API.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("pizzzadata/api/[controller]")]
    public class AdminController : Controller
    {
        private readonly PizzzaDatabaseContext _context;

        public AdminController(PizzzaDatabaseContext context)
        {
            _context = context;
        }

        // GET: pizzzadata/api/admin
        [HttpGet]
        public IActionResult Get()
        {
            var adminRec = new List<PizzzaAdmin>();
            foreach (var record in _context.PizzzaAdmin)
            {
                adminRec.Add(record);
            }

            return new ObjectResult(adminRec);
        }

        // GET: pizzzadata/api/admin/1
        [HttpGet("{adminId=1}")]
        public IActionResult Get(int adminId)
        {
            var adminRec = _context.PizzzaAdmin.FirstOrDefault(y => y.AdminId == adminId);

            return new ObjectResult(adminRec);
        }

        // POST pizzzadata/api/admin
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT pizzzadata/api/admin
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE pizzzadata/api/admin
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
