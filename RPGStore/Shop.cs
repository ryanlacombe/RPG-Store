using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGStore
{
    class Shop : Inventory
    {
        //Creates a Random seed
        Random rand = new Random();

        public Shop()
        {
            Item[] storeStock = { dagger, chain, heal, heal, breath, walking, plate, staff, lbow, robe, spear, lance, leather, silk, clothes, gsword, scale, hunting, hunting };
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
        public void Chat()
        {
            int randChat;

            randChat = rand.Next(0, 5);

            if (randChat == 0)
            {
                Console.WriteLine("'There's been rumors of goblins taking over the old abondoned mine.'");
            }
            else if (randChat == 1)
            {
                Console.WriteLine("'The local tavern: The Dancing Pony, serves the best drinks in the land!'");
            }
            else if (randChat == 2)
            {
                Console.WriteLine("'You should see my brother. He's a weapons trainer.'");
            }
            else if (randChat == 3)
            {
                Console.WriteLine("'Are we talking all day or are you trading something?'");
            }
            else if (randChat == 4)
            {
                Console.WriteLine("'Hey, you. You're finally awake.'");
            }
        }
    }
}
