using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGStore
{
    class Inventory
    {
        public void Remove(Item[] arrayLists, int index)
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
        public void Add(Item[] arrayLists, int index)
        {
            //Creates new array
            Item[] middleList = new Item[arrayLists.Length + 1];
            //Puts values of old arry in new array
            for (int i = 0; i < arrayLists.Length + 1; i++)
            {
                middleList[i] = arrayLists[i];
                //Adds the index to the end of the array
                int arrayEnd = arrayLists.Length;
                middleList[arrayEnd] = arrayLists[index];
            }
            //Sets the current array to the new array
            arrayLists = middleList;
        }
    }
}
