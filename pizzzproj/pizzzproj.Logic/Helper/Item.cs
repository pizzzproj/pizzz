using System;
using System.Collections.Generic;
using System.Text;

namespace pizzzproj.Logic.Helper
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
