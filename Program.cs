using Survive_the_Wasteland.Rooms;
using Survive_the_Wasteland;
using System.Diagnostics;
using System;

internal class Program
{
    public static bool isProtecting = false;
    public static TimeSpan initialVulnerability = TimeSpan.FromMinutes(4);
    public static Stopwatch stopwatch = new Stopwatch();

    static void Main(string[] args)
    {
        var game = new Game();
        game.Add(new HomeBase());
        game.Add(new Location());
        game.Add(new InfestedForests());
        game.Add(new Wastelands());
        game.Add(new ToxicWasteDump());
        game.Add(new Hospital());
        game.Add(new NPC());

        game.Add(new Medic("Dr. Lith"));
        game.Add(new Gardener("Eyva"));

        stopwatch.Start();

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
            Console.WriteLine(game.CurrentRoomDescription);
            string choice = Console.ReadLine()?.ToLower() ?? "";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            game.ReceiveChoice(choice);
            Console.ResetColor();
        }

        stopwatch.Stop();

        TimeSpan elapsedTime = stopwatch.Elapsed;

        Console.WriteLine($"Total time elapsed: {elapsedTime}");

        Console.WriteLine("END");
        Console.ReadLine();
    }

}
