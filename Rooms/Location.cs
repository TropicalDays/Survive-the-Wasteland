using Survive_the_Wasteland;
using Survive_the_Wasteland.Rooms;
using System;

namespace Survive_the_Wasteland.Rooms
{
    internal class Location : Room
    {
        public static bool hasHazardEquipment = true;
        private Random random = new Random();

        internal override string CreateDescription() => @"1. [infested forest] 1 1/2hour, Dense woodlands teeming with hostile mutated creatures and hidden 
dangers.
2. [wastelands] 30 minutes, Desolate landscapes filled with toxic waste and mutated flora and fauna.
3. [toxic waste dump] 1 hour, Hazardous areas rife with radioactive barrels, toxic pools, and mutated 
monstrosities.
4. [home base] A fortified sanctuary where survivors gather to rest, craft, trade, and plan their next moves.";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "infested forest":
                case "1":
                    if (hasHazardEquipment)
                    {
                        Program.initialVulnerability -= TimeSpan.FromMinutes(1);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("You venture and arrive at the Infested Forest.");
                        Console.ResetColor();
                        Game.Transition<InfestedForests>();
                    }
                    else
                    {
                        DisplayRandomEquipmentMessage();
                    }
                    break;
                case "wasteland":
                case "2":
                    Program.initialVulnerability -= TimeSpan.FromSeconds(30);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("You venture and arrive at the Wasteland.");
                    Console.ResetColor();
                    Game.Transition<Wastelands>();
                    break;
                case "toxic waste dump":
                case "3":
                    if (hasHazardEquipment)
                    {
                        Program.initialVulnerability -= TimeSpan.FromMinutes(1);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("You venture and arrive at the Toxic Waste Dump.");
                        Console.ResetColor();
                        Game.Transition<ToxicWasteDump>();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        DisplayRandomEquipmentMessage();
                        Console.ResetColor();
                    }
                    break;
                case "home base":
                case "4":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("You decide to stay at your Home Base.");
                    Console.ResetColor();
                    Game.Transition<HomeBase>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }

        private void DisplayRandomEquipmentMessage()
        {
            string[] messages = new string[]
            {
                "You might want to consider acquiring more suitable equipment before embarking on a journey to that location.",
                "You might want to consider acquiring some additional equipment before embarking on a journey to that particular location.",
                "You currently lack the necessary equipment for embarking on a journey to that specific location."
            };

            int index = random.Next(messages.Length);
            Console.WriteLine(messages[index]);
        }
    }
}
