using Survive_the_Wasteland;
using System;

public enum NPCType
{
    Medic,
    Smith,
    Engineer,
    Gardener
}

internal class NPC : Room
{
    public string Name { get; set; }
    public NPCType Type { get; set; }

    internal override void ReceiveChoice(string choice)
    {
        Introduce();
        Dialog();
    }
    public NPC(string name = "Unknown", NPCType type = NPCType.Engineer)
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
    
    internal override string CreateDescription() => "";
}