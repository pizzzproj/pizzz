using pizzzproj.Data.Helper;
using System;
using Xunit;
using pizzzproj.Logic;

namespace pizzzproj.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var i = new Pizza() { PizzaId = 1, PizzaName = "Cheese", PizzaSizeId = "small" };

            var actual = AddPizza(i);

            Assert.True(actual);

        }

        [Fact]
        public void Test2()
        {
            //var i = new OrderPizzaLogic() { PizzaId = 1; PizzaName = "Cheese", PizzaSizeId = "Small" };
        }
    }
}
