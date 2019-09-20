using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGStore
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName = "";

            Console.WriteLine("Welcome! What is your name?");
            playerName = Console.ReadLine();

            Game game = new Game();
            game.Print();

            Console.ReadKey();
        }
    }
}
