using System;
using System.Collections.Generic;

namespace pizzzadata.Models
{
    public partial class MenuItem
    {
        public MenuItem()
        {
            MenuItemPrice = new HashSet<MenuItemPrice>();
        }

        public int MenuId { get; set; }
        public string Item { get; set; }

        public ICollection<MenuItemPrice> MenuItemPrice { get; set; }
    }
}
