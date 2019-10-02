using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RPGStore
{
    class Program
    {
        static string playerName = "";
        static string input = "";

        static void Main(string[] args)
        {
            Game game = new Game();
            Console.WriteLine("What is your name?");
            playerName = Console.ReadLine();

            if (File.Exists("player"))
            {
                Console.WriteLine("Would you like to load a game?");
                Console.WriteLine("1: Yes");
                Console.WriteLine("2: No");
                input = Console.ReadLine();
                if (input == "1")
                {
                    //Loads the save file
                    game.Load("player", "store");

                    //Prints out the intro to a loaded character
                    Console.WriteLine("\nYou find your way to the familiar sight of the Iron Horse store");
                    Console.WriteLine("(Press Any Key to continue)");
                    Console.ReadKey();
                    Console.WriteLine("\nOnce you open the door and enter, the merchant waves you over.");
                    Console.WriteLine("'Welcome back, " + playerName + "! Happy to see you stop by again!'");
                    Console.WriteLine("(Press Any Key to continue)");
                    Console.ReadKey();
                }
                else
                {
                    //Prints out the intro to a new character
                    Console.WriteLine("\nAfter a quick search through the village, you find a suitible store: Iron Horse.");
                    Console.WriteLine("(Press Any Key to continue)");
                    Console.ReadKey();
                    Console.WriteLine("\nYou enter through the door.");
                    Console.WriteLine("You take a quick look of the interior from your current position.");
                    Console.WriteLine("There are various bits and bobs that adorn the walls around you.");
                    Console.WriteLine("Opposite both you and the door, is a counter and a man standing behind it.");
                    Console.WriteLine("You move forwards to reach the counter.");
                    Console.WriteLine("(Press Any Key to continue)");
                    Console.ReadKey();
                    Console.WriteLine("\nOnce you reach your destination, the man takes notice of your presence.");
                    Console.WriteLine("'Welcome to the Iron Horse! What is your name traveller?'");
                    Console.WriteLine("You decide to give the merchant your name. What could be the harm in it?");
                    Console.WriteLine("'Odd name... But, ah! I have a number of items useful to travellers such as yourself!'");
                    Console.WriteLine("(Press Any Key to continue)");
                    Console.ReadKey();
                }
            }
            //Prints a tranistion into the main Game
            Console.WriteLine("\n'So, what are you looking for, " + playerName + "?'");
            Console.WriteLine("(Press Any Key to continue)");
            Console.ReadKey();

            //Runs the main Game
            game.Menu(playerName);

            //Prints the outro to the user
            Console.WriteLine("\nYou say your goodbyes and thanks to the merchant.");
            Console.WriteLine("You open and exit the door onto the village street, continuing your journey.");
            Console.WriteLine("(Press Any Key to exit the Game)");
            Console.ReadKey();
        }
    }
}
