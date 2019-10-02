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
            playerFunds = 250;
            shopFunds = 500;
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
                        Save("player", "store");
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
            //Creates variables for the function
            string inspectInput = "";
            int menuNumber = 2;
            //Creates empty Arrays to seperate items in class distinctions
            Item[] weaponArray = new Item[0];
            Item[] armorArray = new Item[0];
            Item[] potionArray = new Item[0];

            while (inspectInput != "0")
            {
                Console.WriteLine("\nWhat are you doing?");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: Sort");
                if (itemStat == "Damage")
                {
                    for (int p = 0; p < arrayLists.Length; p++)
                    {
                        if (arrayLists[p].GetItemStatName() == "Damage")
                        {
                            player.Add(weaponArray, arrayLists[p]);
                            weaponArray = player.playerList;                               
                        }
                    }
                    for (int h = 0; h < weaponArray.Length; h++)
                    {
                        Console.WriteLine(menuNumber + ": " + weaponArray[h].GetName());
                        menuNumber++;
                    }
                }
                else if (itemStat == "Defense")
                {
                    for (int p = 0; p < arrayLists.Length; p++)
                    {
                        if (arrayLists[p].GetItemStatName() == "Defense")
                        {
                            player.Add(armorArray, arrayLists[p]);
                            armorArray = player.playerList;
                        }
                    }
                    for (int h = 0; h < armorArray.Length; h++)
                    {
                        Console.WriteLine(menuNumber + ": " + armorArray[h].GetName());
                        menuNumber++;
                    }
                }
                else if (itemStat == "Buff")
                {
                    for (int p = 0; p < arrayLists.Length; p++)
                    {
                        if (arrayLists[p].GetItemStatName() == "Buff")
                        {
                            player.Add(potionArray, arrayLists[p]);
                            potionArray = player.playerList;
                        }
                    }
                    for (int h = 0; h < potionArray.Length; h++)
                    {
                        Console.WriteLine(menuNumber + ": " + potionArray[h].GetName());
                        menuNumber++;
                    }
                }
                else if (itemStat == "Stat")
                {                    
                    for (int h = 0; h < arrayLists.Length; h++)
                    {
                        Console.WriteLine(menuNumber + ": " + arrayLists[h].GetName());
                        menuNumber++;
                    }
                }                
                inspectInput = Console.ReadLine();

                if (inspectInput == "1")
                {
                    inventory.Sort(arrayLists, itemStat);
                }
                if (itemStat == "Damage")
                {
                    for (int b = 0; b < weaponArray.Length; b++)
                    {
                        if (Convert.ToInt32(inspectInput) == (b + 2))
                        {
                            Console.WriteLine("");
                            Console.WriteLine(weaponArray[b].GetName() + ":");
                            Console.WriteLine(itemStat + ": " + weaponArray[b].GetStat());
                            Console.WriteLine("Cost: " + weaponArray[b].GetCost());
                            Console.WriteLine(weaponArray[b].GetDescription());
                            inspectInput = "0";
                        }
                    }
                }
                else if (itemStat == "Defense")
                {
                    for (int b = 0; b < armorArray.Length; b++)
                    {
                        if (Convert.ToInt32(inspectInput) == (b + 2))
                        {
                            Console.WriteLine("");
                            Console.WriteLine(armorArray[b].GetName() + ":");
                            Console.WriteLine(itemStat + ": " + armorArray[b].GetStat());
                            Console.WriteLine("Cost: " + armorArray[b].GetCost());
                            Console.WriteLine(armorArray[b].GetDescription());
                            inspectInput = "0";
                        }
                    }
                }
                else if (itemStat == "Buff")
                {
                    for (int b = 0; b < potionArray.Length; b++)
                    {
                        if (Convert.ToInt32(inspectInput) == (b + 2))
                        {
                            Console.WriteLine("");
                            Console.WriteLine(potionArray[b].GetName() + ":");
                            Console.WriteLine(itemStat + ": " + potionArray[b].GetStat());
                            Console.WriteLine("Cost: " + potionArray[b].GetCost());
                            Console.WriteLine(potionArray[b].GetDescription());
                            inspectInput = "0";
                        }
                    }
                }
                else if (itemStat == "Stat")
                {
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
        public void Save(string path1, string path2)
        {
            //Creates a writer for file at path1
            StreamWriter writer = File.CreateText(path1);
            //Saves the length of current array
            writer.WriteLine(playerInventory.Length);            
            //Saves the player's funds
            writer.WriteLine(playerFunds);
            //Creates loop to save player inventory
            foreach (Item p in playerInventory)
            {
                p.SaveInventories(writer);
            }
            
            //Closes
            writer.Close();

            //Creates a writer for file at path2
            StreamWriter writer2 = File.CreateText(path2);
            //Saves the length of current array
            writer2.WriteLine(storeInventory.Length);            
            //Saves the shop's funds
            writer2.WriteLine(shopFunds);
            //Creates loop to save store inventory
            foreach (Item u in storeInventory)
            {
                u.SaveInventories(writer2);
            }
            //Closes
            writer2.Close();
        }
        public void Load(string path1, string path2)
        {
            //Creates a variable for array length
            int arrayLength = 0;            

            //Checks if there's a file at path1 and path2
            if (File.Exists(path1) && File.Exists(path2))
            {
                //Creates a reader for file at path1
                StreamReader reader = File.OpenText(path1);
                //Loads the array's length
                arrayLength = Convert.ToInt32(reader.ReadLine());
                //Creates and initializes an array to load path1 into
                Item[] emptyArray1 = new Item[arrayLength];
                for (int i = 0; i < emptyArray1.Length - 1; i++)
                {
                    emptyArray1[i] = playerInventory[i];
                    emptyArray1[arrayLength - 1] = new Weapons("null", 0, 0, 0, "null", "null");
                }                
                //Loads the player's funds
                playerFunds = Convert.ToInt32(reader.ReadLine());
                //Creates loop to load and place items into the player inventory
                foreach (Item p in emptyArray1)
                {
                    p.LoadInventories(reader);                   
                }
                //Sets the current array to the player's inventory
                playerInventory = emptyArray1;
                //Closes reader
                reader.Close();

                //Creates a reader for file at path2
                StreamReader reader2 = File.OpenText(path2);
                //Loads the array's length
                arrayLength = Convert.ToInt32(reader2.ReadLine());
                //Creates and initializes an array to load path2 into
                Item[] emptyArray2 = new Item[arrayLength];
                for (int i = 0; i < emptyArray2.Length - 1; i++)
                {
                    emptyArray2[i] = storeInventory[i];
                    emptyArray2[arrayLength - 1] = new Weapons("null", 0, 0, 0, "null", "null");
                }
                //Sets current array to store's inventory
                storeInventory = emptyArray2;                                
                //Loads the store's funds
                shopFunds = Convert.ToInt32(reader2.ReadLine());
                //Creates loop to load and place items into the store inventory
                foreach (Item u in storeInventory)
                {
                    if (u is Item)
                    {
                        u.LoadInventories(reader2);
                    }
                }
                //Set the current array to the store's inventory
                storeInventory = emptyArray2;
                //Closes
                reader2.Close();
            }
            else
            {
                Console.WriteLine("No saves found.");
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
                        //Checks the input and reacts accordingly
                        for (int o = 0; o < fullInventory.Length; o++)
                        {
                            if (Convert.ToInt32(debugInput) == (o + 1))
                            {
                                Console.WriteLine("");
                                Console.WriteLine("You add the " + fullInventory[o].GetName() + " to your inventory.");
                                player.Add(playerInventory, fullInventory[o]);
                                playerInventory = player.playerList;
                                //Exits the Add function
                                Console.WriteLine("\nPress any key to continue.");
                                Console.ReadKey();
                                debugInput = "0";
                            }
                        }
                    }
                    else if (debugInput == "2")
                    {
                        Console.WriteLine("What are you removing?");
                        for (int i = 0; i < playerInventory.Length; i++)
                        {
                            Console.WriteLine((i + 1) + ": " + playerInventory[i].GetName());
                        }
                        debugInput = Console.ReadLine();
                        //Checks the input and reacts accordingly
                        for (int o = 0; o < playerInventory.Length; o++)
                        {
                            if (Convert.ToInt32(debugInput) == (o + 1))
                            {
                                Console.WriteLine("");
                                Console.WriteLine("You remove the " + fullInventory[o].GetName() + " from your inventory.");
                                player.Remove(playerInventory, o);
                                playerInventory = player.playerList;
                                //Exits the Remove function
                                Console.WriteLine("\nPress any key to continue.");
                                Console.ReadKey();
                                debugInput = "0";
                            }
                        }
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
                        //Checks the input and reacts accordingly
                        for (int o = 0; o < fullInventory.Length; o++)
                        {
                            if (Convert.ToInt32(debugInput) == (o + 1))
                            {
                                Console.WriteLine("");
                                Console.WriteLine("You add the " + fullInventory[o].GetName() + " to the store's inventory.");
                                shop.Add(storeInventory, fullInventory[o]);
                                storeInventory = shop.storeList;
                                //Exits the Add function
                                Console.WriteLine("\nPress any key to continue.");
                                Console.ReadKey();
                                debugInput = "0";
                            }
                        }
                    }
                    else if (debugInput == "2")
                    {
                        Console.WriteLine("What are you removing?");
                        for (int i = 0; i < storeInventory.Length; i++)
                        {
                            Console.WriteLine((i + 1) + ": " + storeInventory[i].GetName());
                        }
                        debugInput = Console.ReadLine();
                        //Checks the input and reacts accordingly
                        for (int o = 0; o < playerInventory.Length; o++)
                        {
                            if (Convert.ToInt32(debugInput) == (o + 1))
                            {
                                Console.WriteLine("");
                                Console.WriteLine("You remove the " + storeInventory[o].GetName() + " from the store's inventory.");
                                shop.Remove(storeInventory, o);
                                storeInventory = shop.storeList;
                                //Exits the Remove function
                                Console.WriteLine("\nPress any key to continue.");
                                Console.ReadKey();
                                debugInput = "0";
                            }
                        }
                    }
                }
            }
        }
    }
}
