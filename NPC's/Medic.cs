using System;

internal class Medic : NPC
{
    public Medic(string name) : base(name, NPCType.Medic)
    {
    }

    public override void Introduce()
    {
        Console.WriteLine($"Hello, I'm {Name}, your friendly neighborhood medic!");
    }

    public override void Dialog()
    {
        Console.WriteLine($"{Name}: How can I help you?");
        Console.WriteLine("You can ask about health, request medical supplies, or anything else you need.");
    }

    public override void Interact(string choice)
    {
        switch (choice)
        {
            case "health":
            case "1":
                Console.WriteLine($"{Name} says: I can help you with medical supplies if you need.");
                break;
            case "supplies":
            case "2":
                Console.WriteLine($"{Name} says: Sure, I have some supplies for you.");
                // Add code to give medical supplies to the player
                break;
            default:
                Console.WriteLine($"{Name} doesn't respond to that.");
                break;
        }
    }
}
