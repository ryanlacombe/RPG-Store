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

        static void Main(string[] args)
        {            

            Console.WriteLine("Welcome! What is your name?");
            playerName = Console.ReadLine();

            Game game = new Game();
            game.Menu(playerName);

            Console.ReadKey();
        }
    }
}
