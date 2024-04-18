using Survive_the_Wasteland.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survive_the_Wasteland.Rooms
{
    internal class HomeBase : Room
    {
        internal override string CreateDescription() => @"1. [rest] at the worn-out cot to regain your strength.
2. [craft] useful items at the makeshift workbench using gathered resources.
3. [location] Explore your next journey outside your Home Base.
4. [save progress] by laying down on the makeshift bed, hoping for a moment's respite.
5. [inventory] Display your inventory.";


        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "location":
                case "3":
                    Console.WriteLine("Select your next location.");
                    Game.Transition<Location>();
                    break;
                case "2314":
                    Console.WriteLine("The chest opens and you get a key.");
                    break;
                case "inventory":
                case "5":
                    Console.WriteLine("You look inside your inventory.");
                    Game.playerInventory.DisplayInventory();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
