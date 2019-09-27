using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGStore
{
    class Inventory
    {
        //Creates the Inventory Arrays
        public Item[] playerList;
        public Item[] storeList;
        public Item[] fullList;
        //Creats bool variable for loop
        bool sorted = false;
        //Creates Weapons
        protected Weapons sword = new Weapons("Sword", 10, 15, 18, "Damage", "This is a test description");
        protected Weapons dagger = new Weapons("Dagger", 4, 6, 4, "Damage", "Temp Desc");

        //Creates Armors
        protected Armor leather = new Armor("Leather", 10, 15, 11, "Defense", "This is a test description");

        //Creates Potions
        protected Potions heal = new Potions("Heal", 0, 10, 8, "Buff", "This is a test description");

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
        public void Sort(Item[] arrayToSort, string itemStat)
        {
            string sortInput;
            int firstArgument;
            int secondArgument;

            //Aks User for specific sort function
            Console.WriteLine("\nHow would you like to sort?");
            Console.WriteLine("1: Alphabetical");
            Console.WriteLine("2: Cost");
            Console.WriteLine("3: " + itemStat);
            sortInput = Console.ReadLine();
            //Reads the User's input
            if (sortInput == "1")
            {
                while (!sorted)
                {
                    for (int e = 0; e < arrayToSort.Length - 1; e++)
                    {
                        sorted = true;
                        firstArgument = arrayToSort[e].GetAlphaID();
                        secondArgument = arrayToSort[e + 1].GetAlphaID();
                        if (firstArgument > secondArgument)
                        {
                            Item swapValue = arrayToSort[e];
                            arrayToSort[e] = arrayToSort[e + 1];
                            arrayToSort[e + 1] = swapValue;
                            sorted = false;
                        }
                    }
                }
            }
            else if (sortInput == "2")
            {
                while (!sorted)
                {
                    for (int e = 0; e < arrayToSort.Length - 1; e++)
                    {
                        sorted = true;
                        firstArgument = arrayToSort[e].GetCost();
                        secondArgument = arrayToSort[e + 1].GetCost();
                        if (firstArgument > secondArgument)
                        {
                            Item swapValue = arrayToSort[e];
                            arrayToSort[e] = arrayToSort[e + 1];
                            arrayToSort[e + 1] = swapValue;
                            sorted = false;
                        }
                    }
                }
            }
            else if (sortInput == "3")
            {
                while (!sorted)
                {
                    sorted = true;
                    for (int e = 0; e < arrayToSort.Length - 1; e++)
                    {
                        firstArgument = arrayToSort[e].GetStat();
                        secondArgument = arrayToSort[e + 1].GetStat();
                        if (firstArgument > secondArgument)
                        {
                            Item swapValue = arrayToSort[e];
                            arrayToSort[e] = arrayToSort[e + 1];
                            arrayToSort[e + 1] = swapValue;
                            sorted = false;
                        }
                        Console.WriteLine(arrayToSort[e].GetStat());
                    }
                }
            }
        }        
    }
}
