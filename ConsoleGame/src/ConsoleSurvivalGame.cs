using GameFramework;

namespace ConsoleGame;

public class ConsoleSurvivalGame : Game
{
    public ConsoleSurvivalGame(TextWriter outputWriter, TextReader inputReader, TimeSpan gameLoopInterval) 
        : base(outputWriter, inputReader, gameLoopInterval)
    {
        this.StartedGame += () => Console.WriteLine("Started game");
        this.StoppedGame += () => Console.WriteLine("Stopped game");
    }
}