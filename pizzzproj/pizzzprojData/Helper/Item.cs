using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pizzzprojData.Helper
{
    public partial class Item
    {
        public Item()
        {

        }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemSize { get; set; }
        public List<Item> Items = new List<Item>();
    }
}


