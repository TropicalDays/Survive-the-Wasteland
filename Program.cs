using Survive_the_Wasteland.Rooms;
using Survive_the_Wasteland;
using System.Diagnostics;
using System;

internal class Program
{
    public static bool isProtecting = false;

    static void Main(string[] args)
    {
        var game = new Game();
        game.Add(new HomeBase());
        game.Add(new Location());
        game.Add(new InfestedForests());
        game.Add(new Wastelands());
        game.Add(new ToxicWasteDump());
        game.Add(new Hospital());

        Stopwatch stopwatch = new Stopwatch();
        TimeSpan initialAir = TimeSpan.FromHours(2);

        stopwatch.Start();

        while (!game.IsGameOver())
        {
            TimeSpan remainingAir = initialAir - (isProtecting ? TimeSpan.FromTicks(stopwatch.Elapsed.Ticks * 2) : stopwatch.Elapsed);
            Console.WriteLine("\n--------------------------------------------");
            Console.WriteLine($"Air left: {remainingAir.Hours}h {remainingAir.Minutes}m {remainingAir.Seconds}s\n");
            Console.WriteLine(game.CurrentRoomDescription);
            string choice = Console.ReadLine()?.ToLower() ?? "";
            Console.Clear();
            game.ReceiveChoice(choice);
        }

        stopwatch.Stop();

        TimeSpan elapsedTime = stopwatch.Elapsed;

        Console.WriteLine($"Total time elapsed: {elapsedTime}");

        Console.WriteLine("END");
        Console.ReadLine();
    }
}
