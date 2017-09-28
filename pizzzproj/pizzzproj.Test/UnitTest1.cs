using pizzzproj.Data.Helper;
using System;
using Xunit;
using pizzzproj.Logic;
using System.Collections.Generic;

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

        [Fact]
        public void FindItem()
        {
            var search = "Pepperoni";
            List<ItemLogic> Items = new List<ItemLogic>();
            var uno = new ItemLogic {ItemId = 1, ItemName = "Pepperoni", ItemSize = "Large" };
            var dos = new ItemLogic { ItemId = 2, ItemName = "Meat Lovers", ItemSize = "Small" };
            var tres = new ItemLogic { ItemId = 3, ItemName = "Tequila", ItemSize = "XXXXXXXXL" };

            Items.Add(uno);
            Items.Add(dos);
            Items.Add(tres);

            var actual = ItemLogic.FindItem(Items, search);

            Assert.Equal(uno.ItemName, search);

        }

        [Fact]
        public void CantFindItem()
        {
            var search = "Coors";
            List<ItemLogic> Items = new List<ItemLogic>();
            var uno = new ItemLogic { ItemId = 1, ItemName = "Pepperoni", ItemSize = "Large" };
            var dos = new ItemLogic { ItemId = 2, ItemName = "Meat Lovers", ItemSize = "Small" };
            var tres = new ItemLogic { ItemId = 3, ItemName = "Tequila", ItemSize = "XXXXXXXXL" };

            Items.Add(uno);
            Items.Add(dos);
            Items.Add(tres);

            var actual = ItemLogic.FindItem(Items, search);

            Assert.NotEqual(uno.ItemName, search);
            Assert.NotEqual(dos.ItemName, search);
            Assert.NotEqual(tres.ItemName, search);

        }
    }
}
