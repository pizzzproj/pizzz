using System;
using System.Collections.Generic;

namespace pizzzadata.Models
{
    public partial class PizzzaAdmin
    {
        public int AdminId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Username { get; set; }
        public string AdminPassword { get; set; }
    }
}
