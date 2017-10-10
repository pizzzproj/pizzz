using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pizzzadata.API.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
    }
}
