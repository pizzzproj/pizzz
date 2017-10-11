using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pizzzadata.API.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemSize { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
    }
}
