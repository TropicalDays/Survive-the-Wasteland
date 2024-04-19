using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survive_the_Wasteland
{
    internal class Inventory
    {
        private List<Item> items;

        public Inventory()
        {
            items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void RemoveItem(Item item) 
        {
            items.Remove(item);
        }

        public void DisplayInventory()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\t Inventory ");
            Console.WriteLine("----------------------------");
            Console.ResetColor();
            foreach(Item item in items)
            {
                Console.WriteLine($" - {item.Name}: {item.Description}");
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("----------------------------");
            Console.ResetColor();
        }
    }
}
