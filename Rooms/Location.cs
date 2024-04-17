using Survive_the_Wasteland;
using Survive_the_Wasteland.Rooms;
using System;

namespace Survive_the_Wasteland.Rooms
{
    internal class Location : Room
    {
        private bool hasHazardEquipment = true;
        private Random random = new Random();

        internal override string CreateDescription() => @"1. [infested forest] Dense woodlands teeming with hostile mutated creatures and hidden dangers.
2. [wastelands] Desolate landscapes filled with toxic waste and mutated flora and fauna.
3. [toxic waste dump] Hazardous areas rife with radioactive barrels, toxic pools, and mutated monstrosities.
4. [home base] A fortified sanctuary where survivors gather to rest, craft, trade, and plan their next moves.";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "infested forest":
                case "1":
                    if (hasHazardEquipment)
                    {
                        Console.WriteLine("You venture and arrive at the Infested Forest.");
                        Game.Transition<InfestedForests>();
                    }
                    else
                    {
                        DisplayRandomEquipmentMessage();
                    }
                    break;
                case "wasteland":
                case "2":
                    Console.WriteLine("You venture and arrive at the Wasteland.");
                    Game.Transition<Wastelands>();
                    break;
                case "toxic waste dump":
                case "3":
                    if (hasHazardEquipment)
                    {
                        Console.WriteLine("You venture and arrive at the Toxic Waste Dump.");
                        Game.Transition<ToxicWasteDump>();
                    }
                    else
                    {
                        DisplayRandomEquipmentMessage();
                    }
                    break;
                case "home base":
                case "4":
                    Console.WriteLine("You decide to stay at your Home Base.");
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
