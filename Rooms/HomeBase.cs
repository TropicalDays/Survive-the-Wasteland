using Survive_the_Wasteland.Rooms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survive_the_Wasteland.Rooms
{
    internal class HomeBase : Room
    {
        private Game game;

        public HomeBase(Game game)
        {
            this.game = game;
        }

        internal override string CreateDescription() => @"1. [rest] at the worn-out cot to regain your strength.
2. [npc] Engage in dialogue with fellow survivors, exploring opportunities for crafting, trading, and exchanging
valuable insights.
3. [location] Explore your next journey outside your Home Base.
4. [inventory] Display your inventory.
5. [save progress] by laying down on the makeshift bed, hoping for a moment's respite.
6. [load progress] Load a previously saved game.";


        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "rest":
                case "1":
                    if (!Program.isProtecting)
                    {
                        Program.stopwatch = Stopwatch.StartNew();
                        Program.initialVulnerability = TimeSpan.FromMinutes(4);
                    }
                    else
                    {
                        Program.stopwatch = Stopwatch.StartNew();
                        Program.initialVulnerability = TimeSpan.FromMinutes(4);
                        TimeSpan.FromTicks(Program.stopwatch.Elapsed.Ticks * 2);
                    }
                    Console.WriteLine("You rest and regain your invulnerability to the infection once more.");
                    break;
                case "npc":
                case "2":
                    Console.WriteLine("You approach the group of survivors gathered around a fire.");
                    Console.WriteLine("Who would you like to interact with?");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n--------------------------------------------");
                    Console.WriteLine("1. [Medic]");
                    Console.WriteLine("2. [Gardener]");
                    Console.ResetColor();
                    // Add more NPCs as needed
                    string npcChoice = Console.ReadLine()?.ToLower() ?? "";
                    switch (npcChoice)
                    {
                        case "medic":
                        case "1":
                            Game.Transition<Medic>();
                            break;
                        case "gardener":
                        case "2":
                            Game.Transition<Gardener>();
                            break;
                        default:
                            Console.WriteLine("Invalid NPC choice.");
                            break;
                    }
                    break;
                case "location":
                case "3":
                    Console.WriteLine("Select your next location.");
                    Game.Transition<Location>();
                    break;
                case "save progress":
                case "5":
                    game.SaveProgress();
                    Console.WriteLine("Your progress has been saved.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadLine();
                    break;
                case "inventory":
                case "4":
                    Console.WriteLine("You look inside your inventory.");
                    Game.playerInventory.DisplayInventory();
                    break;
                case "load progress":
                case "6":
                    Game.LoadProgress();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
