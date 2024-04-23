using Survive_the_Wasteland;
using Survive_the_Wasteland.Rooms;
using System;

internal class Engineer : NPC
{
    public static bool newBlade = false;

    public Engineer(string name) : base(name, NPCType.Engineer)
    {
    }

    internal override string CreateDescription() => $@"1. [conversate] Engage in a conversation with Bert regarding the art of Engineering.
2. [fix] Repair malfunctioning equipment.
3. [return] Return to the main part of the Home Base.
4. [inventory] Display your inventory";


    internal override void ReceiveChoice(string choice)
    {
        switch (choice)
        {
            case "smithing":
            case "1":
                Console.WriteLine($"{Name}: I've had the privilege of working as an engineer for four decades now! It's a challenging yet incredibly\n rewarding profession that greatly impacts our daily lives!");
                break;
            case "fix":
            case "2":
                if (Wastelands.repairKitFound)
                {
                    if (Program.isProtecting)
                    {
                        Console.WriteLine("It appears your Gas Mask may need some attention; allow me to assist in restoring it for you!\n");
                        Program.isProtecting = false;
                        Console.WriteLine("Your Gas Mask is now no longer leaking! Come back when ever you need help!");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n Fixed Gas Mask!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"{Name}: I'm sorry, but it seems there's currently nothing in need of repair. Please feel free to return at a later time!");
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
