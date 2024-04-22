using Survive_the_Wasteland;
using System;

public enum NPCType
{
    Medic,
    Guide,
    Smith,
    Scavenger,
    Gardener
}

internal class NPC : Room
{
    public string Name { get; set; }
    public NPCType Type { get; set; }

    public NPC(string name = "Unknown", NPCType type = NPCType.Scavenger)
    {
        Name = name;
        Type = type;
    }

    public virtual void Introduce()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Hello, my name is {Name}. I am a {Type}.");
        Console.ResetColor();
    }

    public virtual void Dialog()
    {
        Console.WriteLine($"What would you like to ask {Name}?");
    }

    public virtual void Interact(string choice)
    {
        switch (choice)
        {
            case "health":
                if (Type == NPCType.Medic)
                {
                    Console.WriteLine($"{Name} says: I can help you with medical supplies if you need.");
                }
                else
                {
                    Console.WriteLine($"{Name} says: I'm not the right person to ask about that.");
                }
                break;
            case "gardener":
                if (Type == NPCType.Guide)
                {
                    Console.WriteLine($"{Name} says: I can show you around and give you tips on surviving in the wasteland.");
                }
                else
                {
                    Console.WriteLine($"{Name} says: Sure, I can try to help.");
                }
                break;
            // Add more interaction cases for other NPCs as needed
            default:
                Console.WriteLine($"{Name} doesn't respond to that.");
                break;
        }
    }

    internal override string CreateDescription() => "";

    internal override void ReceiveChoice(string choice)
    {
        Introduce();
        Dialog();
        Interact(choice);
    }
}