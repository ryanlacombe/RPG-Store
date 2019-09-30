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
        //Creates other variables
        protected int start = 0;
        //Creates Weapons
        protected Weapons sword = new Weapons("Sword", 10, 15, 19, "Damage", "This is a test description");
        protected Weapons dagger = new Weapons("Dagger", 4, 6, 4, "Damage", "Temp Desc");
        protected Weapons staff = new Weapons("Staff", 3, 4, 19, "Damage", "Placeholder");
        protected Weapons sbow = new Weapons("Short Bow", 5, 10, 19, "Damage", "Placeholder");
        protected Weapons lbow = new Weapons("Long Bow", 15, 17, 12, "Damage", "Placeholder");
        protected Weapons gsword = new Weapons("Greatsword", 25, 24, 7, "Damage", "Placeholder");

        //Creates Armors
        protected Armor leather = new Armor("Leather", 5, 15, 11, "Defense", "This is a test description");
        protected Armor chain = new Armor("Chainmail", 10, 20, 3, "Defense", "Placeholder");
        protected Armor plate = new Armor("Plate Armor", 20, 50, 16, "Defense", "Placeholder");
        protected Armor scale = new Armor("Scalemail", 15, 27, 19, "Defense", "Placeholder");
        protected Armor robe = new Armor("Robes", 3, 5, 18, "Defense", "Placeholder");
        protected Armor clothes = new Armor("Clothing", 2, 2, 3, "Defense", "Placeholder");

        //Creates Potions
        protected Potions heal = new Potions("Heal", 0, 10, 8, "Buff", "This is a test description");
        protected Potions strength = new Potions("Strength Potion", 1, 14, 19, "Buff", "Placeholder");
        protected Potions breath = new Potions("Water Breath Potion", 2, 22, 23, "Buff", "Placeholder");
        protected Potions walking = new Potions("Water Walking Potion", 3, 26, 23, "Buff", "placeholder");
        protected Potions vision = new Potions("Night Vision Potion", 4, 18, 14, "Buff", "Placeholder");

        public Inventory()
        {
            Item[] fullStock = { sword, leather, dagger, heal, staff, chain, strength, breath, plate, walking, scale, sbow, robe, vision, clothes, lbow, gsword };
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
            int unpass = arrayToSort.Length - 1;
            sorted = false;
            start = 0;

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
                    sorted = true;
                    for (int r = unpass; r > start; r--)
                    {
                        firstArgument = arrayToSort[r - 1].GetAlphaID();
                        secondArgument = arrayToSort[r].GetAlphaID();
                        if (firstArgument > secondArgument)
                        {
                            Item swapValue = arrayToSort[r - 1];
                            arrayToSort[r - 1] = arrayToSort[r];
                            arrayToSort[r] = swapValue;
                            sorted = false;
                        }
                    }
                    start++;                    
                    for (int e = start; e < unpass; e++)
                    {

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
                    unpass--;
                }
            }
            else if (sortInput == "2")
            {
                while (!sorted)
                {
                    sorted = true;                    
                    for (int r = unpass; r > start; r--)
                    {
                        firstArgument = arrayToSort[r - 1].GetCost();
                        secondArgument = arrayToSort[r].GetCost();
                        if (firstArgument > secondArgument)
                        {
                            Item swapValue = arrayToSort[r - 1];
                            arrayToSort[r - 1] = arrayToSort[r];
                            arrayToSort[r] = swapValue;
                            sorted = false;
                        }
                    }
                    start++;
                    for (int e = start; e < unpass; e++)
                    {

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
                    unpass--;
                }
            }
            else if (sortInput == "3")
            {
                while (!sorted)
                {
                    sorted = true;                    
                    for (int r = unpass; r > start; r--)
                    {
                        firstArgument = arrayToSort[r - 1].GetStat();
                        secondArgument = arrayToSort[r].GetStat();
                        if (firstArgument > secondArgument)
                        {
                            Item swapValue = arrayToSort[r - 1];
                            arrayToSort[r - 1] = arrayToSort[r];
                            arrayToSort[r] = swapValue;
                            sorted = false;
                        }
                    }
                    start++;
                    for (int e = start; e < unpass; e++)
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
                    }
                    unpass--;
                }
            }
        }        
    }
}
