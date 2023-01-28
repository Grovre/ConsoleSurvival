using GameFramework;
using GameFramework.Modules;

namespace ConsoleGame;

public static class Runner
{
    public static void Main()
    {
        Console.WriteLine($"PID: {Environment.ProcessId}");
        var game = new ConsoleSurvivalGame
            (Console.Out, TimeSpan.FromSeconds(1/60D), false);
        game.Loop.NextIteration += c => Console.WriteLine($"Iteration #{c}");
        new Timer(_ => Console.WriteLine("1 sec"), null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        game.Start().Wait(TimeSpan.FromSeconds(15));
        game.Stop();
    }
}