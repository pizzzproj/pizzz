using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace pizzzUI.Models
{
    public class pizzzUIContext : DbContext
    {
        public pizzzUIContext (DbContextOptions<pizzzUIContext> options)
            : base(options)
        {
        }

        public DbSet<pizzzUI.Models.Item> Item { get; set; }
    }
}
