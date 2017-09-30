using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pizzzprojData.Helper
{
    public class Pizza
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
