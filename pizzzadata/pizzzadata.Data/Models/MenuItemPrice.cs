using System;
using System.Collections.Generic;

namespace pizzzadata.Data.Models
{
    public partial class MenuItemPrice
    {
        public int Id { get; set; }
        public int? MenuId { get; set; }
        public int? SizeId { get; set; }
        public decimal? Price { get; set; }

        public MenuItem Menu { get; set; }
        public ItemSize Size { get; set; }
    }
}
