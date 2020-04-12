using System;
using System.Collections.Generic;
using System.Text;

namespace Inventaria.Models
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Item() { }

        public Item(string PlName, string PlDiscr)
        {
            Name = PlName;
            Description = PlDiscr;
        }
    }
}
