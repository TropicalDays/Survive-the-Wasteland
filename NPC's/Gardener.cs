using System;
using System.Collections.Generic;

internal class Gardener : NPC
{

    public Gardener(string name) : base(name, NPCType.Gardener)
    {
    }

    public override void Introduce()
    {
        Console.WriteLine($"Greetings! I'm {Name}, your friendly neighborhood gardener!");
    }

    public override void Dialog()
    {
        Console.WriteLine($"{Name}: How can I assist you today?");
        Console.WriteLine("Feel free to ask about plants, gardening tips, or anything related to nature.\n");
        Console.WriteLine("1. [plants]");
    }

    public override void Interact(string choice)
    {
        switch (choice)
        {
            case "plants":
            case "1":
                Console.WriteLine($"{Name}: Ah, plants are my passion! What do you want to know about them?");
                break;
            case "tips":
            case "2":
                ProvideGardeningTip();
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
        Console.WriteLine($"{Name} says: Here's a gardening tip for you: {gardeningTips[index]}");
    }
}
