using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGStore
{
    class Item
    {
        protected int itemCost;
        protected string itemName;
        protected string itemDescription;

        public string GetName()
        {
            return itemName;
        }
        public string GetDescription()
        {
            return itemDescription;
        }
    }
}
