using Survive_the_Wasteland.Rooms;
using Survive_the_Wasteland;
using System.Diagnostics;
using System;

internal class Program
{
    public static bool isProtecting = false;
    public static TimeSpan initialVulnerability = TimeSpan.FromMinutes(4);
    public static Stopwatch stopwatch = new Stopwatch();
    public static Stopwatch totalTimeStopWatch = new Stopwatch();
    public static int deathCounter = 0;

    static void Main(string[] args)
    {
        var game = new Game();
        game.Add(new HomeBase(game));
        game.Add(new Location());
        game.Add(new InfestedForests());
        game.Add(new Wastelands());
        game.Add(new ToxicWasteDump());
        game.Add(new Hospital());
        game.Add(new NPC());
        game.Add(new Death());

        game.Add(new Smith("Bert"));
        game.Add(new Gardener("Eyva"));
        game.Add(new Engineer("Emerson"));
        game.Add(new Medic("Dr. Luth"));

        stopwatch.Start();
        totalTimeStopWatch.Start();

        RunGameLoop(game);

        stopwatch.Stop();
        totalTimeStopWatch.Stop();
        
        TimeSpan totalElapsedTime = totalTimeStopWatch.Elapsed;

        Console.WriteLine($"\nTotal time elapsed: {totalElapsedTime}");

        Console.WriteLine("\nEND");
        Console.ReadLine();
    }

    static void RunGameLoop(Game game)
    {
        while (!game.IsGameOver())
        {
            TimeSpan remainingVulnerability = initialVulnerability - (isProtecting ? TimeSpan.FromTicks(stopwatch.Elapsed.Ticks * 2) : stopwatch.Elapsed);
            Console.WriteLine("\n--------------------------------------------");
            if (isProtecting && remainingVulnerability.Minutes >= 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"Infected Timer: {remainingVulnerability.Minutes}h {remainingVulnerability.Seconds}m x2 leaking speed\n");
                Console.ResetColor();
            }
            else if (isProtecting && remainingVulnerability.Minutes < 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Infected Timer: {remainingVulnerability.Minutes}h {remainingVulnerability.Seconds}m x2 leaking speed\n");
                Console.ResetColor();
            }
            else if (remainingVulnerability.Minutes >= 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"Infected Timer: {remainingVulnerability.Minutes}h {remainingVulnerability.Seconds}m\n");
                Console.ResetColor();
            }
            else if (remainingVulnerability.Minutes < 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Infected Timer: {remainingVulnerability.Minutes}h {remainingVulnerability.Seconds}m\n");
                Console.ResetColor();
            }

            if (remainingVulnerability <= TimeSpan.Zero)
            {
                Game.Transition<Death>();
            }
            Console.WriteLine(game.CurrentRoomDescription);
            Console.ForegroundColor = ConsoleColor.Blue;
            string choice = Console.ReadLine()?.ToLower() ?? "";
            Console.ResetColor();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            game.ReceiveChoice(choice);
            Console.ResetColor();
        }
    }

}
