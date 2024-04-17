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

        internal override string CreateDescription() => @"1. [supplies] There might be medical supplies or useful items left behind.
2. [wander] Consider conducting an examination of the expansive hospital premises to search for any potential survivors.
3. [examine computer] Search the computer for any pertinent information.
4. [return] Turn back to the Toxic Waste Dump main area.";

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
                    if (count == 0)
                    {
                        int password = range.Next(1, 100000);
                        generatedPassword = password.ToString("");
                        Console.WriteLine($"As you explore the accessible computer files, you come across a document labeled \"password,\" revealing a numeric entry: {generatedPassword}.");
                        count++;
                    }
                    else
                    {
                        Console.WriteLine($"As you explore the accessible computer files, you come across a document labeled \"password,\" revealing a numeric entry: {generatedPassword}.");
                    }
                    break;
                case "return":
                case "4":
                    Console.WriteLine("You return back to the Toxic Waste Dump.");
                    Game.Transition<ToxicWasteDump>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
