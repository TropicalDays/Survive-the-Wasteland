using Survive_the_Wasteland;
using Survive_the_Wasteland.Rooms;
using System;

internal class Smith : NPC
{
    public static bool newBlade = false;

    public Smith(string name) : base(name, NPCType.Smith)
    {
    }

    internal override string CreateDescription() => $@"1. [smithing] Engage in a conversation with Bert regarding the art of smithing.
2. [trade] Trade with {Name}.
3. [return] Return to the main part of the Home Base.
4. [inventory] Display your inventory";


    internal override void ReceiveChoice(string choice)
    {
        switch (choice)
        {
            case "smithing":
            case "1":
                Console.WriteLine($"{Name}: Engaging in smithing brings me immense fulfillment! Not only does it serve as a welcome distraction from\n troubling events, but it also contributes to the sense of security among fellow survivors.");
                break;
            case "trade":
            case "2":
                if (ToxicWasteDump.wornBladeFound)
                {
                    if (!newBlade)
                    {
                        Console.WriteLine($"{Name}: I shall repair anything or make anything you want!");
                        Console.WriteLine($"{Name}: It appears your blade has seen its fair share of use. Allow me to restore its former glory, presenting it\n anew for battle-ready performance!");
                        Item newblade = new Item("New Blade", "Equipped for genuine combat with optimal durability.");
                        Game.playerInventory.AddItem(newblade);
                        newBlade = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n +1 New Blade");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"You seem to have exhausted your options for now!");
                    }

                }
                else
                {
                    Console.WriteLine($"{Name}: I'm sorry, but it seems there's currently nothing in need of repair. Please feel free to return at a later time!");
                }

                break;
            case "return":
            case "3":
                Game.Transition<HomeBase>();
                break;
            case "inventory":
            case "4":
                Console.WriteLine("You look inside your inventory.");
                Game.playerInventory.DisplayInventory();
                break;
            default:
                Console.WriteLine($"{Name} doesn't respond to that.");
                break;
        }
    }
}
