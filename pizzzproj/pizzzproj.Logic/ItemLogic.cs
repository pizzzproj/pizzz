using pizzzproj.Logic.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace pizzzproj.Logic
{
    public class ItemLogic
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemSize { get; set; }
        public static List<ItemLogic> Items = new List<ItemLogic>();

        public static ItemLogic AddItem(ItemLogic item)
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

        public static ItemLogic FindItem(List<ItemLogic> Items, string searchItem)
        {

           return Items.Find(x => x.ItemName.Contains(searchItem));

        }

        public static bool OrderEmpty(List<ItemLogic> Items)
        {
            if(Items.Count == 0)
            {
                return true;
            }
                return false;
        }

        public static ItemLogic EditOrderItemSize(ItemLogic Item, string size)
        {
            Item.ItemSize = size;
            return Item;
        }

        public static List<ItemLogic> AddMultipleItems(List<ItemLogic> Items, ItemLogic CItem, int HowMany)
        {
          if(HowMany <= 0  ||  HowMany % 2 != 0)
            {
                throw new ArgumentException("Quantity input is incorrect");
            }
        
            for(int i = 0; i < HowMany; i++)
            {
                CItem.ItemId++;
                Items.Add(CItem);
            }
            return Items;
        }
    }
}
