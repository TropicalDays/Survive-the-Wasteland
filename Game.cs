using Survive_the_Wasteland.Rooms;
using System;
using System.Collections.Generic;

namespace Survive_the_Wasteland
{
    internal class Game
    {
        public static Inventory playerInventory = new Inventory();
        public static TimeSpan playerHealth = TimeSpan.FromMinutes(4);
        private static SaveData currentSaveData;


        List<Room> rooms = new List<Room>();
        Room currentRoom;
        internal bool IsGameOver() => isFinished;
        static bool isFinished;
        static string nextRoom = "";

        internal void Add(Room room)
        {
            rooms.Add(room);
            if (currentRoom == null)
            {
                currentRoom = room;
            }
        }

        internal string CurrentRoomDescription => currentRoom.CreateDescription();

        internal void ReceiveChoice(string choice)
        {
            currentRoom.ReceiveChoice(choice);
            CheckTransition();
        }

        internal static void Transition<T>() where T : Room
        {
            nextRoom = typeof(T).Name;
        }

        internal static void Finish()
        {
            isFinished = true;
        }

        internal void CheckTransition()
        {
            foreach (var room in rooms)
            {
                if (room.GetType().Name == nextRoom)
                {
                    nextRoom = "";
                    currentRoom = room;
                    break;
                }
            }
        }

        internal void SaveProgress()
        {
            currentSaveData = new SaveData
            {
                CurrentRoom = currentRoom.GetType().Name,
                CurrentHealth = playerHealth,
                CollectedItems = playerInventory.GetItems()
            };

            SaveGameManager.SaveGame(currentSaveData);
            Console.WriteLine("Progress saved. Press any key to continue.");
            Console.ReadKey();
        }

        internal static void LoadProgress()
        {
            currentSaveData = SaveGameManager.LoadGame();
            if (currentSaveData != null)
            {
                Console.WriteLine("Progress loaded.");
            }
        }
    }
}
