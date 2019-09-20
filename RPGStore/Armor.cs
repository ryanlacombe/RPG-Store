using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGStore
{
    class Armor : Item
    {
        private int _defense;

        public Armor(string newName, int newDefense, int newCost, string newDescription)
        {
            itemName = newName;
            _defense = newDefense;
            itemCost = newCost;
            itemDescription = newDescription;
        }
        public int GetDefense()
        {
            return _defense;
        }        
    }
}
