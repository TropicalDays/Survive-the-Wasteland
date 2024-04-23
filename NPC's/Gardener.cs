using Survive_the_Wasteland;
using Survive_the_Wasteland.Rooms;
using System;
using System.Collections.Generic;

internal class Gardener : NPC
{
    private bool givenSeed = false;
    public static bool knowsTheEnd = false;

    public Gardener(string name) : base(name, NPCType.Gardener)
    {
    }

    internal override string CreateDescription() => $@"1. [plants] Engage in a pleasant conversation with {Name} regarding plants.
2. [tips] Get some helpful pointers on plants.
3. [trade] Trade with {Name}.
4. [return] Return to the main part of the Home Base.
5. [inventory] Display your inventory";


    internal override void ReceiveChoice(string choice)
    {
        switch (choice)
        {
            case "plants":
            case "1":
                Console.WriteLine($"{Name}: Isn't it fascinating that there are still some plants thriving despite the challenges of the wasteland age?");
                break;
            case "tips":
            case "2":
                ProvideGardeningTip();
                break;
            case "trade":
            case "3":
                if (InfestedForests.seedFound)
                {
                    if (!givenSeed)
                    {
                        {
                            Console.WriteLine($"{Name}: It seems you've stumbled upon quite a lush and fertile seed, one that holds promise for future food cultivation!");
                            Console.WriteLine($"{Name}: I'd gladly offer some exploration book in exchange for that seed!");
                        jump1: Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\n Do you accept this trade? [y/n]");
                            string trade = Console.ReadLine()?.ToLower();
                            Console.ResetColor();
                            if (trade == "y")
                            {
                                givenSeed = true;
                                Console.Clear();
                                Console.WriteLine($"{Name}: Much appreciated for the trade! Wishing you safe and enjoyable journeys with your new exploration book!");
                                Item explorationBook = new Item("Exploration Book", "Some suggest that this book offers guidance on escaping the challenges of the land.\n Journeying through the infested Forest, one may discover a realm abundant with harvestable crops and vibrant scenery.\n However, few have ventured deeply into the forest, hindered by its unforgiving climates.");
                                Game.playerInventory.AddItem(explorationBook);
                                knowsTheEnd = true;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n +1 Exploration Book");
                                Console.ResetColor();
                            }
                            else if (trade == "n")
                            {
                                Console.WriteLine($"{Name}: Wishing you much success with those seeds. Come back another time! Have a wonderful day!");
                            }
                            else
                            {
                                Console.WriteLine("Invalid Command");
                                goto jump1;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"{Name}: I'm afraid it seems you don't have anything suitable to trade at the moment. If you come across anything plant\n like, feel free to reach out!");
                }
                break;
            case "return":
                case "4":
                Game.Transition<HomeBase>();
                break;
            case "inventory":
            case "5":
                Console.WriteLine("You look inside your inventory.");
                Game.playerInventory.DisplayInventory();
                break;
            default:
                Console.WriteLine($"{Name} doesn't respond to that.");
                break;
        }
    }

    private readonly List<string> gardeningTips = new List<string>
    {
        "Water your plants regularly, but be careful not to overwater them.",
        "Make sure your plants get enough sunlight for healthy growth.",
        "Use organic fertilizers to nourish your plants without harmful chemicals.",
        "Keep an eye out for pests and diseases, and address them promptly.",
        "Prune your plants regularly to promote strong growth and shape.",
        "Rotate your crops to prevent soil depletion and maintain fertility."
    };

    private void ProvideGardeningTip()
    {
        Random random = new Random();
        int index = random.Next(gardeningTips.Count);
        Console.WriteLine($"{Name}: Here's a gardening tip for you: {gardeningTips[index]}");
    }
}
