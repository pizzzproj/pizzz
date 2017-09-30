using System;
using System.Collections.Generic;
using System.Text;

namespace pizzzproj.Logic.Helper
{
    public partial class Pizza
    {

        public Pizza()
        {

        }

        public int PizzaId { get; set; }
        public string PizzaName { get; set; }
        public string PizzaSizeId { get; set; }
        public List<Pizza> Pizzas { get; set; }
    }
}
