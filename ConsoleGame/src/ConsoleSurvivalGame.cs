using GameFramework;

namespace ConsoleGame;

public class ConsoleSurvivalGame : Game
{
    public ConsoleSurvivalGame(TextWriter consoleOutputWriter, TimeSpan gameLoopInterval, bool loopGameAsync = false) 
        : base(consoleOutputWriter, gameLoopInterval, loopGameAsync)
    {
        this.StartedGame += () => Console.WriteLine("Started game");
        this.StoppedGame += () => Console.WriteLine("Stopped game");
    }
}