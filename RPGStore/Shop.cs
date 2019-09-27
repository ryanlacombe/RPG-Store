using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGStore
{
    class Shop : Inventory
    {
        public Shop()
        {
            Item[] storeStock = { dagger, leather, heal };
            storeList = storeStock;
        }
        public override void Remove(Item[] arrayLists, int index)
        {
            storeList = arrayLists;
            //Creates new array
            Item[] newList = new Item[storeList.Length - 1];
            //Puts values of old array in new array
            int newPosition = 0;
            for (int i = 0; i < storeList.Length; i++)
            {
                if (i != index)
                {
                    newList[newPosition] = storeList[i];
                    newPosition++;
                }
            }
            //Set the current array to the new array
            storeList = newList;
        }
        public override void Add(Item[] arrayLists, Item index)
        {
            storeList = arrayLists;
            //Creates new array
            Item[] middleList = new Item[storeList.Length + 1];
            //Puts values of old arry in new array
            int newposition = 0;
            for (int i = 0; i < storeList.Length + 1; i++)
            {
                if (i != storeList.Length)
                {
                    middleList[newposition] = storeList[i];
                    newposition++;
                }
                //Adds the index to the end of the array
                int arrayEnd = storeList.Length;
                middleList[arrayEnd] = index;
            }
            //Sets the current array to the new array
            storeList = middleList;
        }
    }
}
