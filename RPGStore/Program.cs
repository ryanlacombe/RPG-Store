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

            Console.WriteLine("Would you like to load a game? (Y/N)");
            input = Console.ReadLine();
            if (input == "Y" || input == "y")
            {
                game.Load("player", "store", playerName);
            }
            else if (input == "N" || input == "n")
            {
                Console.WriteLine("Welcome! What is your name?");
                playerName = Console.ReadLine();
            }

            Console.WriteLine("Welcome! What is your name?");
            playerName = Console.ReadLine();

            
            game.Menu(playerName);

            Console.ReadKey();
        }
    }
}
