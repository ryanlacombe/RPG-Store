using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGStore
{
    class Game
    {
        private Item[] testInventory;

        private Weapons sword = new Weapons("Sword", 10, 15, "This is a test description");
        private Armor leather = new Armor("Leather", 10, 15, "This is a test description");
        private Potions heal = new Potions("Heal", 0, 10, "This is a test description");

        public Game()
        {
            Item[] testInventory2 = new Item[3];
            testInventory2[0] = sword;
            testInventory2[1] = leather;
            testInventory2[2] = heal;
            testInventory = testInventory2;
        }
        public void Print()
        {
            for (int i = 0; i < testInventory.Length; i++)
            {
                Console.WriteLine(testInventory[i].GetName());
                Console.WriteLine(testInventory[i].GetDescription());
            }
        }
    }
}
