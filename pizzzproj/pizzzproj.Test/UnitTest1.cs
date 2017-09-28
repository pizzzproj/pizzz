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
            
            var i = new Item() { ItemId = 1, ItemName = "Sausage", ItemSize = "big"};

            var actual = ItemLogic.AddItem(i);

            Assert.Equal(actual.ItemId, i.ItemId);
            Assert.Equal(actual.ItemName, i.ItemName);
            Assert.Equal(actual.ItemSize, i.ItemSize);
        }

        [Fact]
        public void Test2()
        {
            var i = new Item() { ItemId = 1, ItemName = "Pizza", ItemSize = "Huge"};
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
    }
}
