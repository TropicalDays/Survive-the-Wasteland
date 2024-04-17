using Survive_the_Wasteland.Rooms;
using Survive_the_Wasteland;
using Survive_the_Wasteland.Rooms;
using System;

namespace Survive_the_Wasteland
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Add(new HomeBase());
            game.Add(new Location());
            game.Add(new InfestedForests());
            game.Add(new Wastelands());
            game.Add(new ToxicWasteDump());

            while (!game.IsGameOver())
            {
                Console.WriteLine("--");
                Console.WriteLine(game.CurrentRoomDescription);
                string choice = Console.ReadLine().ToLower() ?? "";
                Console.Clear();
                game.ReceiveChoice(choice);
            }

            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}