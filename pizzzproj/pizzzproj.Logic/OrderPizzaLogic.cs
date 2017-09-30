using pizzzproj.Data.Helper;
using pizzzproj.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace pizzzproj.Logic
{
    public class OrderPizzaLogic
    {

        public int PizzaId { get; set; }
        public string PizzaName { get; set; }
        public string PizzaSizeId { get; set; }
        public static List<OrderPizzaLogic> Pizzas = new List<OrderPizzaLogic>();

        public static OrderPizzaLogic AddPizza(Pizza pizza)
        {
            var addPizza = new OrderPizzaLogic()
            {
                PizzaId = pizza.PizzaId,
                PizzaName = pizza.PizzaName,
                PizzaSizeId = pizza.PizzaSizeId
            };

            Pizzas.Add(addPizza);

            return addPizza;            
        }

      
    }
}
