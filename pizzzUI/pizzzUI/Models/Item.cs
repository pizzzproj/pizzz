using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pizzzUI.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; } 
        public string ItemSize { get; set; }
        public decimal ItemPrice { get; set; }
    }
}
