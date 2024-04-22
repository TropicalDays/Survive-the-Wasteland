using Survive_the_Wasteland;
using System;
using System.Collections.Generic;

public class SaveData
{
    public string CurrentRoom { get; set; }
    public TimeSpan CurrentHealth { get; set; }
    public List<Item> CollectedItems { get; set; }

    public SaveData()
    {
        CollectedItems = new List<Item>();
    }
}

