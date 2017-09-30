using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pizzzprojData.Helper
{
    public class Side
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
