using System;
using Xunit;
using pizzzproj.Logic;
using pizzzproj.Data;
using pizzzproj.Test;

namespace pizzzproj.Test
{
    public class UnitTest1
    {
        [Fact]
        public void addOrderItem()
        {
            var i = new OrderPizzaLogic() { PizzaId = 1, PizzaName = "Cheese Lovers", PizzaSizeId = "Small" };
          //  var j = new OrderPizzaLogic() { IDisposable = 2, Name = "Pepperoni", Size = "Large" };

            var actual = i.AddPizza();

            Assert.True(actual);
        }
    }
}
