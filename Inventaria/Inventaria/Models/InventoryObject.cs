using System;
using System.Collections.Generic;
using System.Text;

namespace Inventaria.Models
{
    public class InventoryObject : Item
    {

        private static int count = 0;
        public int ID { get; }
        public InventoryCategory Category { get; set; }
        public InventoryObject(): this("","", InventoryCategory.Other) { }

        public InventoryObject(string PlName, string PlDiscr, InventoryCategory inventoryCategory) : base(PlName, PlDiscr)
        {
            ID = ++count;
            Category = inventoryCategory;
        }
    }
}
