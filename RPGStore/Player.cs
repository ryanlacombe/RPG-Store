using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGStore
{
    class Player : Inventory
    {
        public Player()
        {
            Item[] playerStock = { sword, heal, dagger, leather };
            playerList = playerStock;
        }
        public override void Remove(Item[] arrayLists, int index)
        {
            playerList = arrayLists;
            //Creates new array
            Item[] newList = new Item[playerList.Length - 1];
            //Puts values of old array in new array
            int newPosition = 0;
            for (int i = 0; i < playerList.Length; i++)
            {
                if (i != index)
                {
                    newList[newPosition] = playerList[i];
                    newPosition++;
                }
            }
            //Set the current array to the new array
            playerList = newList;
        }
        public override void Add(Item[] arrayLists, Item index)
        {
            playerList = arrayLists;
            //Creates new array
            Item[] middleList = new Item[playerList.Length + 1];
            //Puts values of old arry in new array
            int newposition = 0;
            for (int i = 0; i < playerList.Length + 1; i++)
            {
                if (i != playerList.Length)
                {
                    middleList[newposition] = playerList[i];
                    newposition++;
                }
                //Adds the index to the end of the array
                int arrayEnd = playerList.Length;
                middleList[arrayEnd] = index;
            }
            //Sets the current array to the new array
            playerList = middleList;
        }
    }
}
