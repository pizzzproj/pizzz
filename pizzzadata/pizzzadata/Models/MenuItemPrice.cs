using System;
using System.Collections.Generic;

namespace pizzzadata.Models
{
    public partial class MenuItemPrice
    {
        public int Id { get; set; }
        public int? MenuId { get; set; }
        public int? SizeId { get; set; }
        public decimal? Price { get; set; }

        public MenuItems Menu { get; set; }
        public ItemSizes Size { get; set; }
    }
}
