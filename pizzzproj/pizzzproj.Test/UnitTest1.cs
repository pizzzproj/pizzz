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
            var i = new Item() { ItemId = 1, ItemName = "Pizza", ItemSize = "Huge" };

            var i1 = new Item() { ItemId = 2, ItemName = "Pizza", ItemSize = "big" };

            var m = ItemLogic.AddItem(i);

            var n = ItemLogic.AddItem(i1);

            var actual = ItemLogic.DeleteSingleItem(m.ItemId);

            Assert.True(actual);
        }

        [Fact]

        public void Test3()

        {
            var i = new Item() { ItemId = 1, ItemName = "Pizza", ItemSize = "small" };

            var m = ItemLogic.AddItem(i);

            var actual = ItemLogic.DeleteAllItems();

            Assert.True(actual);

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

        [Fact]
        public void OrderIsEmpty()
        {
            List<ItemLogic> Items = new List<ItemLogic>();

            var actual = ItemLogic.OrderEmpty(Items);

            Assert.True(actual);
        }

        [Fact]
        public void OrderIsNotEmpty()
        {
            List<ItemLogic> Items = new List<ItemLogic>();
            var uno = new ItemLogic { ItemId = 1, ItemName = "Pepperoni", ItemSize = "Large" };
            var dos = new ItemLogic { ItemId = 2, ItemName = "Meat Lovers", ItemSize = "Small" };
            var tres = new ItemLogic { ItemId = 3, ItemName = "Tequila", ItemSize = "XXXXXXXXL" };

            Items.Add(uno);
            Items.Add(dos);
            Items.Add(tres);


            var actual = ItemLogic.OrderEmpty(Items);

            Assert.False(actual);
        }

        [Fact]
        public void EditSizeItem()
        {
            var uno = new ItemLogic { ItemId = 1, ItemName = "Pepperoni", ItemSize = "Large" };
            var newSize = "XXXXL";

            var actual = ItemLogic.EditOrderItemSize(uno, newSize);

            Assert.Equal(actual.ItemSize, uno.ItemSize);
        }

        [Fact]
        public void AddSameItems()
        {
            List<ItemLogic> Items = new List<ItemLogic>();
            var uno = new ItemLogic { ItemId = 1, ItemName = "Pepperoni", ItemSize = "Large" };
            var dos = new ItemLogic { ItemId = 2, ItemName = "Meat Lovers", ItemSize = "Small" };

            Items.Add(uno);
            Items.Add(dos);

            var tres = new ItemLogic { ItemId = 3, ItemName = "Tequila", ItemSize = "XXXXXXXXL" };
            var i = 3;


            var actual = ItemLogic.AddMultipleItems(Items, tres, i);

            Assert.Equal(actual[2].ItemId, tres.ItemId);
            Assert.Equal(actual[3].ItemId, tres.ItemId);
            Assert.Equal(actual[4].ItemId, tres.ItemId);

            Assert.Equal(actual[2].ItemName, tres.ItemName);
            Assert.Equal(actual[3].ItemName, tres.ItemName);
            Assert.Equal(actual[4].ItemName, tres.ItemName);

            Assert.Equal(actual[2].ItemSize, tres.ItemSize);
            Assert.Equal(actual[3].ItemSize, tres.ItemSize);
            Assert.Equal(actual[4].ItemSize, tres.ItemSize);

        }

        [Fact]
        public void NonNegativeAddMultipleItems()
        {
            List<ItemLogic> Items = new List<ItemLogic>();
            var uno = new ItemLogic { ItemId = 1, ItemName = "Pepperoni", ItemSize = "Large" };
            var dos = new ItemLogic { ItemId = 2, ItemName = "Meat Lovers", ItemSize = "Small" };

            Items.Add(uno);
            Items.Add(dos);

            var tres = new ItemLogic { ItemId = 3, ItemName = "Tequila", ItemSize = "XXXXXXXXL" };
            var i = -3;
            var check = 3;


            var actual = ItemLogic.AddMultipleItems(Items, tres, i);

            Assert.NotEqual(i, check);
            

        }


    }
}
