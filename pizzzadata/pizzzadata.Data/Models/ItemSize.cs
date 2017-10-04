using System;
using System.Collections.Generic;

namespace pizzzadata.Data.Models
{
    public partial class ItemSize
    {
        public ItemSize()
        {
            MenuItemPrice = new HashSet<MenuItemPrice>();
        }

        public int SizeId { get; set; }
        public string Size { get; set; }

        public ICollection<MenuItemPrice> MenuItemPrice { get; set; }
    }
}
