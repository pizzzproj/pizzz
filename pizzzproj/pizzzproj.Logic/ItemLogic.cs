using System;
using System.Collections.Generic;
using System.Text;
using pizzzproj.Data.Helper;
using System.Linq;

namespace pizzzproj.Logic
{
    public class ItemLogic
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

        public static bool DeleteAllItems()
        {
            Items.Clear();
            if(Items.Count == 0)
            {
                return true;
            }
            return false;
        }

    }
}
