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
        //Creates bool variables for while loops
        bool inStore = true;        
        //Creates the Inventory Arrays
        static protected Item[] playerInventory;
        static protected Item[] storeInventory;
        static private Item[] fullInventory;
        //Creates fund variables
        protected int playerFunds;
        protected int shopFunds;
        //Creates instance of the Inventory Classes
        Player player = new Player();
        Shop shop = new Shop();
        Inventory inventory = new Inventory();
        
        //Creates other variables
        protected string itemStat;

        public Game()
        {
            playerInventory = player.playerList;            
            storeInventory = shop.storeList;
            fullInventory = inventory.fullList;
            playerFunds = 100;
            shopFunds = 200;
        }
        public int GetPlayerFunds()
        {
            return playerFunds;
        }
        public int GetShopFunds()
        {
            return shopFunds;
        }
        public string GetItemStatName()
        {
            return itemStat;
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
                    //Asks User for input
                    Console.WriteLine("\nWould you like to save?");
                    Console.WriteLine("1: Yes");
                    Console.WriteLine("2: No");
                    //Gets User's input
                    input = Console.ReadLine();
                    //Checks the input
                    if (input == "1")
                    {
                        Save("player", "store", userName);
                        inStore = false;
                    }
                    else if (input == "2")
                    {
                        inStore = false;
                    }
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
                            InspectInventory(playerInventory);
                        }
                        else if (input == "2")
                        {
                            itemStat = "Defense";
                            InspectInventory(playerInventory);
                        }
                        else if (input == "3")
                        {
                            itemStat = "Buff";
                            InspectInventory(playerInventory);
                        }
                        else if (input == "4")
                        {
                            itemStat = "Stat";
                            InspectInventory(playerInventory);
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
                            InspectInventory(storeInventory);
                        }
                        else if (input == "2")
                        {
                            itemStat = "Defense";
                            InspectInventory(storeInventory);
                        }
                        else if (input == "3")
                        {
                            itemStat = "Buff";
                            InspectInventory(storeInventory);
                        }
                        else if (input == "4")
                        {
                            itemStat = "Stat";
                            InspectInventory(storeInventory);
                        }
                    }
                }
                else if (input == "3")
                {
                    Buy();                    
                }
                else if (input == "4")
                {
                    Sell();
                }
                else if (input == "5")
                {
                    shop.Chat();
                }
                else if (input == "9")
                {
                    DevFunction(userName);
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
        public void InspectInventory(Item[] arrayLists)
        {
            string inspectInput = "";

            while (inspectInput != "0")
            {
                Console.WriteLine("\nWhat are you doing?");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: Sort");
                for (int o = 0; o < arrayLists.Length; o++)
                {
                    if (itemStat == "Damage" && arrayLists[o].GetItemStatName() == "Damage")
                    {
                        Console.WriteLine((o + 2) + ": " + arrayLists[o].GetName());
                    }
                    else if (itemStat == "Defense" && arrayLists[o].GetItemStatName() == "Defense")
                    {
                        Console.WriteLine((o + 2) + ": " + arrayLists[o].GetName());
                    }
                    else if (itemStat == "Buff" && arrayLists[o].GetItemStatName() == "Buff")
                    {
                        Console.WriteLine((o + 2) + ": " + arrayLists[o].GetName());
                    }
                    else if (itemStat == "Stat")
                    {
                        Console.WriteLine((o + 2) + ": " + arrayLists[o].GetName());
                    }
                }
                inspectInput = Console.ReadLine();
                if (inspectInput == "1")
                {
                    inventory.Sort(arrayLists, itemStat);
                }
                for (int b = 0; b < arrayLists.Length; b++)
                {
                    if (Convert.ToInt32(inspectInput) == (b + 2))
                    {
                        Console.WriteLine("");
                        Console.WriteLine(arrayLists[b].GetName() + ":");
                        Console.WriteLine(itemStat + ": " + arrayLists[b].GetStat());
                        Console.WriteLine("Cost: " + arrayLists[b].GetCost());
                        Console.WriteLine(arrayLists[b].GetDescription());
                        inspectInput = "0";
                    }
                }
            }
        }        
        public void Buy()
        {
            //Creates variables for function
            string buyInput = "";
            int userFunds = GetPlayerFunds();
            int storeFunds = GetShopFunds();

            while (buyInput != "0")
            {
                //Asks the User for input
                Console.WriteLine("\nWhat are you purchasing?");
                Console.WriteLine("0: Exit");
                for (int i = 0; i < storeInventory.Length; i++)
                {
                    Console.WriteLine((i + 1) + ": " + storeInventory[i].GetName());
                }
                //Gets User's input
                buyInput = Console.ReadLine();
                //Checks the input and reacts accordingly
                for (int o = 0; o < storeInventory.Length; o++)
                {
                    if (Convert.ToInt32(buyInput) == (o + 1))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("You buy the " + storeInventory[o].GetName() + " for " + storeInventory[o].GetCost() + " gold.");
                        player.Add(playerInventory, storeInventory[o]);
                        playerInventory = player.playerList;
                        playerFunds = (userFunds - storeInventory[o].GetCost());
                        shopFunds = (storeFunds + storeInventory[o].GetCost());
                        shop.Remove(storeInventory, o);
                        storeInventory = shop.storeList;                        
                        Console.WriteLine("Your funds are now: " + GetPlayerFunds());
                        //Exits the Buy function
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        buyInput = "0";
                    }
                }
            }
        }
        public void Sell()
        {
            //Creates variables for function
            string sellInput = "";
            int userFunds = GetPlayerFunds();
            int storeFunds = GetShopFunds();

            while (sellInput != "0")
            {
                //Asks the User for input
                Console.WriteLine("\nWhat are you selling?");
                Console.WriteLine("0: Exit");
                for (int i = 0; i < playerInventory.Length; i++)
                {
                    Console.WriteLine((i + 1) + ": " + playerInventory[i].GetName());
                }
                //Gets User's input
                sellInput = Console.ReadLine();
                //Checks the input and reacts accordingly
                for (int o = 0; o < playerInventory.Length; o++)
                {
                    if (Convert.ToInt32(sellInput) == (o + 1))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("You sell the " + playerInventory[o].GetName() + " for " + playerInventory[o].GetCost() + " gold.");
                        shop.Add(storeInventory, playerInventory[o]);
                        storeInventory = shop.storeList;
                        playerFunds = (userFunds + playerInventory[o].GetCost());
                        shopFunds = (storeFunds - playerInventory[o].GetCost());
                        player.Remove(playerInventory, o);
                        playerInventory = player.playerList;
                        Console.WriteLine("Your funds are now: " + GetPlayerFunds());
                        //Exits the Buy function
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        sellInput = "0";
                    }
                }
            }
        }
        public void Save(string path1, string path2, string userName)
        {
            //Creates a writer for file at path1
            StreamWriter writer = File.CreateText(path1);
            //Denotes the player
            writer.WriteLine(userName + ":");
            //Creates loop to save player inventory
            foreach (Item p in playerInventory)
            {
                p.SaveInventories(writer);
            }
            writer.WriteLine(playerFunds);
            //Closes
            writer.Close();

            //Creates a writer for file at path2
            StreamWriter writer2 = File.CreateText(path2);
            //Denotes the merchant
            writer2.WriteLine("Merchant:");
            //Creates loop to save store inventory
            foreach (Item u in storeInventory)
            {
                u.SaveInventories(writer2);
            }
            writer2.WriteLine(shopFunds);
            //Closes
            writer2.Close();
        }
        public void Load(string path1, string path2, string userName)
        {
            //Checks if there's a file at path1
            if (File.Exists(path1))
            {
                //Creates a reader for file at path1
                StreamReader reader = File.OpenText(path1);
            }
        }
        public void DevFunction(string userName)
        {
            string debugInput = "";

            Console.WriteLine("\nYou have activated the debug function.");
            Console.WriteLine("The debug function allows you to add or remove items from either inventory.");
            while (debugInput != "0")
            {
                Console.WriteLine("\nWhat inventory are you modifying?");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: " + userName);
                Console.WriteLine("2: Merchant");
                debugInput = Console.ReadLine();
                if (debugInput == "1")
                {
                    Console.WriteLine("\nWhat are you doing?");
                    Console.WriteLine("0: Exit");
                    Console.WriteLine("1: Add");
                    Console.WriteLine("2: Remove");
                    debugInput = Console.ReadLine();
                    if (debugInput == "1")
                    {
                        Console.WriteLine("What are you adding?");
                        for (int i = 0; i < fullInventory.Length; i++)
                        {
                            Console.WriteLine((i + 1) + ": " + fullInventory[i].GetName());
                        }
                        debugInput = Console.ReadLine();
                    }
                    else if (debugInput == "2")
                    {
                        Console.WriteLine("What are you removing?");
                        for (int i = 0; i < playerInventory.Length; i++)
                        {
                            Console.WriteLine((i + 1) + ": " + playerInventory[i].GetName());
                        }
                        debugInput = Console.ReadLine();
                    }
                }
                else if (debugInput == "2")
                {
                    Console.WriteLine("\nWhat are you doing?");
                    Console.WriteLine("0: Exit");
                    Console.WriteLine("1: Add");
                    Console.WriteLine("2: Remove");
                    debugInput = Console.ReadLine();
                    if (debugInput == "1")
                    {
                        Console.WriteLine("What are you adding?");
                        for (int i = 0; i < fullInventory.Length; i++)
                        {
                            Console.WriteLine((i + 1) + ": " + fullInventory[i].GetName());
                        }
                        debugInput = Console.ReadLine();
                    }
                    else if (debugInput == "2")
                    {
                        Console.WriteLine("What are you removing?");
                        for (int i = 0; i < storeInventory.Length; i++)
                        {
                            Console.WriteLine((i + 1) + ": " + storeInventory[i].GetName());
                        }
                        debugInput = Console.ReadLine();
                    }
                }
            }
        }
    }
}
