using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGStore
{
    class Potions : Item
    {
        private int _buff;

        public Potions(string newName, int buffId, int newCost, int newAlphaID, string newItemStatName, string newDescription)
        {
            itemName = newName;
            _buff = buffId;
            itemCost = newCost;
            itemDescription = newDescription;
            alphaID = newAlphaID;
            itemStatName = newItemStatName;
        }
        public override int GetStat()
        {
            return _buff;
        }
        public override string GetItemStatName()
        {
            return itemStatName;
        }
    }
}
