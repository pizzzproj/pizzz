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
        public List<PizzzaAdmin> Get()
        {
            try
            {
                return _context.PizzzaAdmin.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // GET: pizzzadata/api/admin/1
        [HttpGet("{adminId=1}")]
        public PizzzaAdmin Get(int adminId)
        {
            try
            {
                return _context.PizzzaAdmin.FirstOrDefault(z => z.AdminId == adminId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // POST pizzzadata/api/admin
        [HttpPost]
        public void Post([FromBody]PizzzaAdmin newAdmin)
        {
            try
            {
                PizzzaAdmin addAdminItem = new PizzzaAdmin
                {
                    Fname = newAdmin.Fname,
                    Lname = newAdmin.Lname,
                    Username = newAdmin.Username,
                    AdminPassword = newAdmin.AdminPassword
                };
                _context.PizzzaAdmin.Add(addAdminItem);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // PUT pizzzadata/api/admin
        [HttpPut("{id}")]
        public void Put([FromBody]PizzzaAdmin updatedAdmin)
        {
            try
            {
                var updated = _context.PizzzaAdmin.FirstOrDefault(z => z.AdminId == updatedAdmin.AdminId);
                updated.Fname = updatedAdmin.Fname;
                updated.Lname = updatedAdmin.Lname;
                updated.Username = updatedAdmin.Username;
                updated.AdminPassword = updatedAdmin.AdminPassword;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // DELETE pizzzadata/api/admin
        [HttpDelete("{id}")]
        public void Delete(PizzzaAdmin deletedAdmin)
        {
            try
            {
                var adminItem = _context.PizzzaAdmin.FirstOrDefault(z => z.AdminId == deletedAdmin.AdminId);
                _context.PizzzaAdmin.Remove(adminItem);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
