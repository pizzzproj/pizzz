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

            var actual = OrderPizzaLogic.AddPizza(i);

            Assert.Equal(actual.PizzaId, i.PizzaId);
            Assert.Equal(actual.PizzaName, i.PizzaName);
            Assert.Equal(actual.PizzaSizeId, i.PizzaSizeId);
        }

        [Fact]
        public void Test2()
        {
            var i = new Side() { SideId = 1, SideName = "Wings", SideSize = "Family" };

            var actual = OrderSideLogic.AddSide(i);

            Assert.Equal(actual.SideId, i.SideId);
            Assert.Equal(actual.SideName, i.SideName);
            Assert.Equal(actual.SideSize, i.SideSize);
        }
    }
}
