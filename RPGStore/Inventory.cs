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
        protected Weapons sword = new Weapons("Sword", 10, 15, 19, "Damage", "A one-handed, double edged blade. A typical longsword with a simple black leather grip.");
        protected Weapons dagger = new Weapons("Dagger", 4, 6, 4, "Damage", "A small, easily concealable blade. It has a oiled brown leather grip.");
        protected Weapons staff = new Weapons("Staff", 3, 4, 19, "Damage", "A long wooden staff. A number of engravings adorned the length of the weapon for those that wish to use it in a magical capacity.");
        protected Weapons sbow = new Weapons("Short Bow", 5, 10, 19, "Damage", "A typical sized bow. Deadly in short ranges, but difficult to reach targets at medium to long ranges. It is adorned with multi-colored feathers.");
        protected Weapons lbow = new Weapons("Long Bow", 15, 17, 12, "Damage", "A bow typically seen used by soldiers in warfare. Deadly at all ranges. Rather plain in details, but is highly customizable.");
        protected Weapons gsword = new Weapons("Greatsword", 25, 26, 7, "Damage", "A massive two-ganded, double edged blade. Very effective against cavalry. It has an alternating black and white leather grip.");
        protected Weapons spear = new Weapons("Spear", 13, 16, 19, "Damage", "A long wooden pole with a bladed point on one end. Typically used in hunting, it can be used two-handed or one-handed with a shield.");
        protected Weapons lance = new Weapons("Lance", 18, 22, 12, "Damage", "A polearm typically used by cavalry, but can be used on foot. The short wooden grip gives way to a long tapered metal body that ends in a deadly, sharpened point.");
        //Creates Armors
        protected Armor leather = new Armor("Leather Armor", 5, 15, 11, "Defense", "A simple set of brown oiled leather gear. Includes a chestpiece, boots, and leggings.");
        protected Armor chain = new Armor("Chainmail", 10, 20, 3, "Defense", "A set of chainmail to be placed under clothing or lighter armor. Includes a chestpiece with long sleeves.");
        protected Armor plate = new Armor("Plate Armor", 20, 50, 16, "Defense", "A set of full plate that can be placed over leather or chainmail. Includes a chestpiece, leggings, boots, guantlets, and helm.");
        protected Armor scale = new Armor("Scalemail", 15, 27, 19, "Defense", "A set of armor that has small steel plates woven together like dragon scales. Protective enough to worn as a standalone. Includes a chestpiece, leggings, boots, and guantlets.");
        protected Armor robe = new Armor("Robes", 3, 5, 18, "Defense", "A single set of robes, the preferred garments of those magically inclined. It is dyed: beige, blue, and red.");
        protected Armor clothes = new Armor("Clothing", 2, 2, 3, "Defense", "A simple set of clothing, that one would typically seen being worn by the gerneral folk all across the land. Includes a tunic, pants, and boots.");
        protected Armor silk = new Armor("Silk Underlay", 5, 18, 19, "Defense", "A longsleeve silken shirt to be placed under any armor. Gives the wearer increased protection to arrows and prevents chaffing.");
        //Creates Potions
        protected Potions heal = new Potions("Healing Potion", 0, 10, 8, "Buff", "A very basic potion used in the healing of wounds and to slightly combat illnesses.");
        protected Potions strength = new Potions("Strength Potion", 1, 14, 19, "Buff", "A potion that bolsters the user's physical prowess.");
        protected Potions breath = new Potions("Water Breath Potion", 2, 22, 23, "Buff", "A potion that allows the user to breathe in water for a short time.");
        protected Potions walking = new Potions("Water Walking Potion", 3, 26, 23, "Buff", "A potion that allows the user to walk on the surface of any body of water.");
        protected Potions vision = new Potions("Night Vision Potion", 4, 18, 14, "Buff", "A potion that allows the user to see at night or dark locations as if it were illuminated by daylight.");
        protected Potions hunting = new Potions("Hunting Potion", 5, 16, 8, "Buff", "A potion that allows the user to see living creatures larger than a mouse (Including people) in a small distance from the user.");
        protected Potions antidote = new Potions("Antidote", 6, 15, 1, "Buff", "A basic potion that is administered to cure poisons and illnesses of a similar nature.");

        public Inventory()
        {
            Item[] fullStock = { sword, leather, dagger, heal, staff, chain, strength, breath, plate, walking, scale, sbow, robe, vision, clothes, lbow, gsword, silk, spear, hunting, lance, antidote };
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
            //Creates variables for the function
            string sortInput;
            int firstArgument;
            int secondArgument;
            int unpass = arrayToSort.Length - 1;
            //Resets specific variables each time the function is called
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
                    //Starts from the end of the array
                    for (int r = unpass; r > start; r--)
                    {
                        //Grabs the first value to be compared
                        firstArgument = arrayToSort[r - 1].GetAlphaID();
                        //Grabs the second value to be compared
                        secondArgument = arrayToSort[r].GetAlphaID();
                        //Compares the two objects by specified parameter
                        if (firstArgument > secondArgument)
                        {
                            Item swapValue = arrayToSort[r - 1];
                            arrayToSort[r - 1] = arrayToSort[r];
                            arrayToSort[r] = swapValue;
                            sorted = false;
                        }
                    }
                    start++;
                    //Moves to the other end of the array
                    for (int e = start; e < unpass; e++)
                    {
                        //Grabs the first value to be compared
                        firstArgument = arrayToSort[e].GetAlphaID();
                        //Grabs the second value to be compared
                        secondArgument = arrayToSort[e + 1].GetAlphaID();
                        //Compares the two objects by specified parameter
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
                        //Grabs the first value to be compared
                        firstArgument = arrayToSort[r - 1].GetCost();
                        //Grabs the second value to be compared
                        secondArgument = arrayToSort[r].GetCost();
                        //Compares the two objects by specified parameter
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
                        //Grabs the first value to be compared
                        firstArgument = arrayToSort[e].GetCost();
                        //Grabs the second value to be compared
                        secondArgument = arrayToSort[e + 1].GetCost();
                        //Compares the two objects by specified parameter
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
                        //Grabs the first value to be compared
                        firstArgument = arrayToSort[r - 1].GetStat();
                        //Grabs the second value to be compared
                        secondArgument = arrayToSort[r].GetStat();
                        //Compares the two objects by specified parameter
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
                        //Grabs the first value to be compared
                        firstArgument = arrayToSort[e].GetStat();
                        //Grabs the second value to be compared
                        secondArgument = arrayToSort[e + 1].GetStat();
                        //Compares the two objects by specified parameter
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
