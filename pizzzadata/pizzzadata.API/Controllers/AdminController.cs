using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pizzzadata.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pizzzadata.API.Controllers
{
    [Route("pizzzadata/api/[controller]")]
    public class AdminController : Controller
    {
        private readonly PizzzaDatabaseContext _context;

        public AdminController(PizzzaDatabaseContext context)
        {
            _context = context;
        }

        //// GET: pizzzadata/api/admin
        //[HttpGet]
        //public PizzzaAdmin Get(int id)
        //{
        //    PizzzaAdmin temp = new PizzzaAdmin();

        //    foreach (var record in _context.PizzzaAdmin)
        //    {
        //        if(id == record.AdminId)
        //        {
        //            temp.AdminId = record.AdminId;
        //            temp.Fname = record.Fname;
        //            temp.Lname = record.Lname;
        //            temp.Username = record.Username;
        //            temp.AdminPassword = record.AdminPassword;
        //            return temp;
        //        }
        //    }

        //    return null;
        //}

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

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
