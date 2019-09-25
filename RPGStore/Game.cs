using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RPGStore
{
    class Game
    {
        //Creates a Random seed
        Random rand = new Random();
        //Creates bool variables for while loops
        bool inStore = true;
        bool sorted = false;
        //Creates the Inventory Arrays
        private Item[] playerInventory;
        private Item[] storeInventory;
        //Creates fund variables
        private int playerFunds;
        private int shopFunds;
        //Creates Weapons
        private Weapons sword = new Weapons("Sword", 10, 15, 2, "This is a test description");
        private Weapons dagger = new Weapons("Dagger", 4, 6, 1, "Temp Desc");

        //Creates Armors
        private Armor leather = new Armor("Leather", 10, 15, 1, "This is a test description");

        //Creates Potions
        private Potions heal = new Potions("Heal", 0, 10, 4, "This is a test description");

        //Creates other variables
        private string itemStat;

        public Game()
        {
            Item[] playerStock = { sword, dagger, leather, heal };
            playerInventory = playerStock;
        }
        public int GetPlayerFunds()
        {
            return playerFunds;
        }
        public int GetShopFunds()
        {
            return shopFunds;
        }
        public void Menu(string userName)
        {
            string input;

            while (inStore)
            {
                Console.WriteLine("\nWhat will you do?");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: View");
                Console.WriteLine("2: Inspect");
                Console.WriteLine("3: Buy");
                Console.WriteLine("4: Sell");
                Console.WriteLine("5: Chat");
                input = Console.ReadLine();

                if (input == "0")
                {
                    inStore = false;
                }
                else if (input == "1")
                {
                    Console.WriteLine("\nWhich inventory are you viewing?");
                    Console.WriteLine("1: " + userName);
                    Console.WriteLine("2: Merchant");
                    input = Console.ReadLine();
                    if (input == "1")
                    {
                        PlayerList();
                    }
                    else if (input == "2")
                    {
                        ShopList();
                    }

                    inStore = true;
                }
                else if (input == "2")
                {
                    Console.WriteLine("\nWhich inventory are you viewing?");
                    Console.WriteLine("1: " + userName);
                    Console.WriteLine("2: Merchant");
                    input = Console.ReadLine();
                    if (input == "1")
                    {
                        Console.WriteLine("Which type of item are you inspecting?");
                        Console.WriteLine("1: Weapons");
                        Console.WriteLine("2: Armors");
                        Console.WriteLine("3: Potions");
                        Console.WriteLine("4: All Items");
                        input = Console.ReadLine();
                        if (input == "1")
                        {
                            itemStat = "Damage";
                            InspectPlayerInventory();
                        }
                        else if (input == "2")
                        {
                            itemStat = "Defense";
                            InspectPlayerInventory();
                        }
                        else if (input == "3")
                        {
                            itemStat = "Buff";
                            InspectPlayerInventory();
                        }
                        else if (input == "4")
                        {
                            itemStat = "Stat";
                            InspectPlayerInventory();
                        }
                    }
                    else if (input == "2")
                    {
                        Console.WriteLine("Which type of item are you inspecting?");
                        Console.WriteLine("1: Weapons");
                        Console.WriteLine("2: Armors");
                        Console.WriteLine("3: Potions");
                        Console.WriteLine("4: All Items");
                        input = Console.ReadLine();
                        if (input == "1")
                        {
                            itemStat = "Damage";
                            InspectStoreInventory();
                        }
                        else if (input == "2")
                        {
                            itemStat = "Defense";
                            InspectStoreInventory();
                        }
                        else if (input == "3")
                        {
                            itemStat = "Buff";
                            InspectStoreInventory();
                        }
                        else if (input == "4")
                        {
                            itemStat = "Stat";
                            InspectStoreInventory();
                        }
                    }

                    inStore = true;
                }
                else if (input == "3")
                {

                }
                else if (input == "4")
                {

                }
                else if (input == "5")
                {
                    Chat();
                }
                else if (input == "9")
                {

                }
            }
        }
        public void PlayerList()
        {
            Console.WriteLine("\nYour Inventory:");
            Console.WriteLine("");
            for (int i = 0; i < playerInventory.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + playerInventory[i].GetName());
            }
            Console.WriteLine("Funds: " + GetPlayerFunds());
        }
        public void ShopList()
        {
            Console.WriteLine("\nMerchant's Inventory:");
            Console.WriteLine("");
            for (int i = 0; i < storeInventory.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + storeInventory[i].GetName());
            }
            Console.WriteLine("Funds: " + GetShopFunds());
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
        public void PlayerSort(Item[] arrayToSort)
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
        public void StoreSort(Item[] arrayToSort)
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
                    for (int e = 0; e < arrayToSort.Length - 1; e++)
                    {
                        sorted = true;
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
                }
            }
        }
        public void InspectPlayerInventory()
        {
            string inspectInput = "";
            int i = 0;

            while (inspectInput != "0")
            {
                Console.WriteLine("\nWhat are you doing?");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: Sort");
                for (int o = 0; o < playerInventory.Length; o++)
                {
                    if (itemStat == "Damage")
                    {
                        Console.WriteLine((o + 2) + ": " + playerInventory[o].GetName());
                        i = o;
                    }
                    else if (itemStat == "Defense")
                    {

                        i = o;
                    }
                    else if (itemStat == "Buff")
                    {

                        i = o;
                    }
                    else if (itemStat == "Stat")
                    {
                        Console.WriteLine((o + 2) + ": " + playerInventory[o].GetName());
                        i = (o - 2);
                    }
                }
                inspectInput = Console.ReadLine();
                if (inspectInput == "1")
                {
                    PlayerSort(playerInventory);
                }
                else if (Convert.ToInt32(inspectInput) == (i + 2))
                {
                    Console.WriteLine("");
                    Console.WriteLine(playerInventory[i].GetName() + ":");
                    Console.WriteLine(itemStat + ": " + playerInventory[i].GetStat());
                    Console.WriteLine("Cost: " + playerInventory[i].GetCost());
                    Console.WriteLine(playerInventory[i].GetDescription());
                    inspectInput = "0";
                }
            }
        }
        public void InspectStoreInventory()
        {
            string inspectInput = "";
            int i = 0;

            while (inspectInput != "0")
            {
                Console.WriteLine("\nWhat are you doing?");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: Sort");
                for (int o = 0; o < storeInventory.Length; o++)
                {
                    if (itemStat == "Damage")
                    {

                        i = o;
                    }
                    else if (itemStat == "Defense")
                    {

                        i = o;
                    }
                    else if (itemStat == "Buff")
                    {

                        i = o;
                    }
                    else if (itemStat == "Stat")
                    {
                        Console.WriteLine((o + 2) + ": " + storeInventory[o].GetName());
                        i = o;
                    }
                }
                inspectInput = Convert.ToString(Console.ReadLine());
                if (inspectInput == "1")
                {
                    StoreSort(storeInventory);
                }
                else if (Convert.ToInt32(inspectInput) == (i + 2))
                {
                    Console.WriteLine(storeInventory[i].GetStat());
                    Console.WriteLine(storeInventory[i].GetCost());
                    Console.WriteLine(storeInventory[i].GetDescription());
                    inspectInput = "0";
                }
            }
        }
    }
}
