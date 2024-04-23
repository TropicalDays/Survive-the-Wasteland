using Survive_the_Wasteland;
using Survive_the_Wasteland.Rooms;
using System;

internal class Medic : NPC
{
    public static bool hasBeenHelped = false;

    public Medic(string name) : base(name, NPCType.Medic)
    {
    }

    internal override string CreateDescription() => $@"1. [conversation] Engage in a conversation with {Name} regarding nursing.
2. [help] Let {Name} treat you.
3. [return] Return to the main part of the Home Base.
4. [inventory] Display your inventory";


    internal override void ReceiveChoice(string choice)
    {
        switch (choice)
        {
            case "conversation":
            case "1":
                Console.WriteLine($"{Name}: Interacting with clients brings me immense satisfaction, and witnessing the smiles of fellow survivors serves\n as a powerful source of motivation for me.");
                break;
            case "help":
            case "2":
                if (Hospital.hasFoundMedkit)
                {
                    if (!hasBeenHelped)
                    {
                        Console.WriteLine($"You're being cared for by {Name}, and it's as if your injured leg never experienced any discomfort in the first place.");
                        hasBeenHelped = true;
                    }
                    else
                    {
                        Console.WriteLine($"You seem to be in perfect shape!");
                    }

                }
                else
                {
                    Console.WriteLine($"You seem to be in perfect shape!");
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
