﻿using System;
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
        protected int itemStat;
        protected string itemStatName;
        protected int alphaID;
        

        public string GetName()
        {
            return itemName;
        }
        public string GetDescription()
        {
            return itemDescription;
        }
        public int GetCost()
        {
            return itemCost;
        }
        public virtual int GetStat()
        {
            return itemStat;
        }
        public int GetAlphaID()
        {
            return alphaID;
        }
        public virtual string GetItemStatName()
        {
            return itemStatName;
        }        
    }
}
