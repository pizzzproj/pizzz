using System;
using System.Collections.Generic;
using System.Text;

namespace pizzzproj.Data.Helper
{
    public partial class Side
    {
        public Side()
        {

        }

        public int SideId { get; set; }
        public string SideName { get; set; }
        public string SideSize { get; set; }
        public List<Side> Sides { get; set; }
    }
}
