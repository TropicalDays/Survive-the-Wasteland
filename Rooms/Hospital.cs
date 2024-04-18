using Survive_the_Wasteland.Rooms;
using Survive_the_Wasteland;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survive_the_Wasteland.Rooms
{
    internal class Hospital : Room
    {
        Random range = new Random();
        internal static string generatedPassword;
        internal int count = 0;
        private bool foundCode = false;

        internal override string CreateDescription() => @"1. [supplies] There might be medical supplies or useful items left behind.
2. [wander] Consider conducting an examination of the expansive hospital premises to search for any potential survivors.
3. [examine computer] Search the computer for any pertinent information.
4. [return] Turn back to the Toxic Waste Dump main area.
5. [inventory] Display your inventory.";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "supplies":
                case "1":
                    Console.WriteLine("You explore the cabinets for any medical supplies and stumble upon a valuable medkit. Although unsure of how to properly\n use it, you decide to hold onto it.");
                    break;
                case "wander":
                case "2":
                    Console.WriteLine("You leisurely explore the vast hospital, but find little of significance to pique your interest.");
                    break;
                case "examine computer":
                case "3":
                    if (!foundCode)
                    {
                        int password = range.Next(1, 100000);
                        generatedPassword = password.ToString("");
                        Console.WriteLine($"As you explore the accessible computer files, you come across a document labeled \"password,\" revealing a numeric entry: {generatedPassword}.");
                        Item passwordInt = new Item("Password", $"A password consisting of digits ({generatedPassword}) for an unspecified location");
                        Game.playerInventory.AddItem(passwordInt);
                        Console.WriteLine("\n +1 Password");
                        foundCode = true;
                    }
                    else
                    {
                        Console.WriteLine($"Beyond what's essential, there aren't any significant contents within the computer.");
                    }
                    break;
                case "return":
                case "4":
                    Console.WriteLine("You return back to the Toxic Waste Dump.");
                    Game.Transition<ToxicWasteDump>();
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
