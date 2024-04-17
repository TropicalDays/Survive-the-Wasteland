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
2. [manage inventory] by accessing the storage chest to deposit or withdraw items.
3. [craft] useful items at the makeshift workbench using gathered resources.
4. [location] Explore your next journey outside your Home Base.
5. [save progress] by laying down on the makeshift bed, hoping for a moment's respite.";


        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "location":
                    Console.WriteLine("Select your next location.");
                    Game.Transition<Location>();
                    break;
                case "4":
                    Console.WriteLine("Select your next location.");
                    Game.Transition<Location>();
                    break;
                case "2314":
                    Console.WriteLine("The chest opens and you get a key.");
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
