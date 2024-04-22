using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

internal class SaveGameManager
{
    private const string saveFilePath = "savegame.dat";

    public static void SaveGame(SaveData data)
    {
        using (FileStream fileStream = new FileStream(saveFilePath, FileMode.Create))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fileStream, data);
        }
    }

    public static SaveData LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            using (FileStream fileStream = new FileStream(saveFilePath, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (SaveData)formatter.Deserialize(fileStream);
            }
        }
        else
        {
            Console.WriteLine("No saved game found.");
            return null;
        }
    }
}
