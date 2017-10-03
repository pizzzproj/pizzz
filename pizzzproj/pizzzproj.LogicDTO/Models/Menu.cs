using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pizzzproj.LogicDTO.Models
{
    public class IEnumerable<Menu>
    {
            public int ItemId { get; set; }
            public string ItemName { get; set; }
            public string ItemSize { get; set; }
            public decimal ItemPrice { get; set; }
        }
    }

