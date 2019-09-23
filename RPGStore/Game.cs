using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGStore
{
    class Game
    {
        //Creates a Random seed
        Random rand = new Random();
        //Creates a bool variable for main menu loop
        bool inStore = true;
        //Creates the Inventory Arrays
        private Item[] playerInventory;
        private Item[] storeInventory;
        //Creates fund variables
        private int playerFunds;
        private int shopFunds;
        //Creates Weapons
        private Weapons sword = new Weapons("Sword", 10, 15, "This is a test description");

        //Creates Armors
        private Armor leather = new Armor("Leather", 10, 15, "This is a test description");

        //Creates Potions
        private Potions heal = new Potions("Heal", 0, 10, "This is a test description");

        //Creates other variables
        private string itemStat;

        public Game()
        {
            Item[] testInventory2 = new Item[3];
            testInventory2[0] = sword;
            testInventory2[1] = leather;
            testInventory2[2] = heal;
            playerInventory = testInventory2;
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

                }
            }
        }
        public void PlayerList()
        {
            Console.WriteLine("Your Inventory:");
            Console.WriteLine("");
            for (int i = 0; i < playerInventory.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + playerInventory[i].GetName());
            }
            Console.WriteLine("Funds: " + GetPlayerFunds());
        }
        public void ShopList()
        {
            Console.WriteLine("Merchant's Inventory:");
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
        public void Sort()
        {
            string sortInput;

            Console.WriteLine("\nHow would you like to sort?");
            Console.WriteLine("0: Alphabetical");
            Console.WriteLine("1: Cost");
            Console.WriteLine("2: " + itemStat);
            sortInput = Console.ReadLine();

            if (sortInput == "0")
            {

            }
            else if (sortInput == "1")
            {

            }
            else if (sortInput == "2")
            {

            }
        }
        public void InspectPLayerInventory()
        {

        }
        public void InspectStoreInventory()
        {

        }
    }
}
