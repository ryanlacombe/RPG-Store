using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
        public void SaveInventories(StreamWriter writer)
        {
            //Creates the save state for passed in array
            if (GetItemStatName() == "Damage")
            {
                writer.WriteLine("Weapon");
                writer.WriteLine(GetName());
                writer.WriteLine(GetStat());
                writer.WriteLine(GetCost());
                writer.WriteLine(GetAlphaID());
                writer.WriteLine(GetItemStatName());
                writer.WriteLine(GetDescription());
            }
            else if (GetItemStatName() == "Defense")
            {
                writer.WriteLine("Armor");
                writer.WriteLine(GetName());
                writer.WriteLine(GetStat());
                writer.WriteLine(GetCost());
                writer.WriteLine(GetAlphaID());
                writer.WriteLine(GetItemStatName());
                writer.WriteLine(GetDescription());
            }
            else if (GetItemStatName() == "Buff")
            {
                writer.WriteLine("Potion");
                writer.WriteLine(GetName());
                writer.WriteLine(GetStat());
                writer.WriteLine(GetCost());
                writer.WriteLine(GetAlphaID());
                writer.WriteLine(GetItemStatName());
                writer.WriteLine(GetDescription());
            }
        }
    }
}
