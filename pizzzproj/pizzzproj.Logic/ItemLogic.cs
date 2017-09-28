using System;
using System.Collections.Generic;
using System.Text;
using pizzzproj.Data.Helper;

namespace pizzzproj.Logic
{
    class ItemLogic
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemSize { get; set; }
        public static List<ItemLogic> Items = new List<ItemLogic>();

        public static ItemLogic AddItem(Item item)
        {
            var addItem = new ItemLogic()
            {
                ItemId = item.ItemId,
                ItemName = item.ItemName,
                ItemSize = item.ItemSize
            };

            Items.Add(addItem);
            return addItem;
        }

        public static bool DeleteSingleItem(int id)
        {
            foreach(var c in Items)
            {
                if (c.ItemId == id)
                {
                    Items.RemoveAt(id);
                    return true;
                }              
            }
            return false;
        }

        public bool DeleteAllItems()
        {
            Items.Clear();
            if(Items.Any())
            {
                return false;
            }
            return true;
        }

    }
}
