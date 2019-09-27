using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGStore
{
    class Inventory
    {
        public Item[] playerList;
        public Item[] storeList;
        public Item[] fullList;
        //Creates Weapons
        protected Weapons sword = new Weapons("Sword", 10, 15, 2, "This is a test description");
        protected Weapons dagger = new Weapons("Dagger", 4, 6, 1, "Temp Desc");

        //Creates Armors
        protected Armor leather = new Armor("Leather", 10, 15, 1, "This is a test description");

        //Creates Potions
        protected Potions heal = new Potions("Heal", 0, 10, 4, "This is a test description");

        public Inventory()
        {
            Item[] fullStock = { sword, leather, dagger, heal };
            fullList = fullStock;
        }
        public virtual void Remove(Item[] arrayLists, int index)
        {
            //Creates new array
            Item[] newList = new Item[arrayLists.Length - 1];
            //Puts values of old array in new array
            int newPosition = 0;
            for (int i = 0; i < arrayLists.Length; i++)
            {
                if (i != index)
                {
                    newList[newPosition] = arrayLists[i];
                    newPosition++;
                }
            }
            //Set the current array to the new array
            arrayLists = newList;
        }
        public virtual void Add(Item[] arrayLists, Item index)
        {
            //Creates new array
            Item[] middleList = new Item[arrayLists.Length + 1];
            //Puts values of old arry in new array
            int newposition = 0;
            for (int i = 0; i < arrayLists.Length + 1; i++)
            {
                if (i != arrayLists.Length)
                {
                    middleList[newposition] = arrayLists[i];
                    newposition++;
                }
                //Adds the index to the end of the array
                int arrayEnd = arrayLists.Length;
                middleList[arrayEnd] = index;
            }
            //Sets the current array to the new array
            arrayLists = middleList;
        }
    }
}
