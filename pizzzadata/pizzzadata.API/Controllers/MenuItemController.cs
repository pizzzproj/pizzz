﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using pizzzadata.API.Models;
using pizzzadata.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pizzzadata.API.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("pizzzadata/api/[controller]")]
    public class MenuItemController : Controller
    {
        private readonly PizzzaDatabaseContext _context;

        public MenuItemController(PizzzaDatabaseContext context)
        {
            _context = context;
        }

        // GET pizzzadata/api/menuitem
        [HttpGet]
        public List<MenuItem> Get()
        {
            return _context.MenuItem.ToList();
        }

        // GET pizzzadata/api/menuitem/itemId
        [HttpGet("{itemId=1}")]
        public MenuItem Get(int itemId)
        {
            return _context.MenuItem.FirstOrDefault(z => z.MenuId == itemId);
            
        }

        // POST pizzzadata/api/menuitem
        [HttpPost]
        public void Post([FromBody]Item newMenuItem)
        {
            MenuItem addMenuItem = new MenuItem
            {
                Item = newMenuItem.ItemName
            };
            _context.MenuItem.Add(addMenuItem);
            _context.SaveChanges();
        }

        // PUT pizzzadata/api/menuitem
        [HttpPut]
        public void Put(string newName, [FromBody]Item updatedMenuItem)
        {
            _context.MenuItem.FirstOrDefault(z => z.Item == updatedMenuItem.ItemName).Item = newName;
            _context.SaveChanges();
        }

        // DELETE pizzzadata/api/menuitem
        [HttpDelete]
        public void Delete([FromBody]Item deletedMenuItem)
        {
            var menuItem = _context.MenuItem.FirstOrDefault(z => z.Item == deletedMenuItem.ItemName);
            _context.MenuItem.Remove(menuItem);
            _context.SaveChanges();
        }
    }
}