using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGStore
{
    class Weapons : Item
    {
        private int _damage;               

        public Weapons(string newName, int newDamage, int newCost, string newDescription)
        {
            itemName = newName;
            _damage = newDamage;
            itemCost = newCost;
            itemDescription = newDescription;
        }
        public int GetStat()
        {
            return _damage;
        }
    }
}
