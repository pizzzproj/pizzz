using pizzzproj.Data.Helper;
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
        
        public static OrderPizzaLogic AddPizza(Pizza pizza)
        {
            var addPizza = new OrderPizzaLogic()
            {
                PizzaId = pizza.PizzaId,
                PizzaName = pizza.PizzaName,
                PizzaSizeId = pizza.PizzaSizeId
            };

            return addPizza;
        }

        public Pizza ReturnPizza(OrderPizzaLogic pizzaLogic)
        {
            return new Pizza()
            {
                PizzaId = pizzaLogic.PizzaId,
                PizzaName = pizzaLogic.PizzaName,
                PizzaSizeId = pizzaLogic.PizzaSizeId
            };
        }
    }
}
