using GameFramework.Modules;

namespace GameFramework;

public class GameContext
{
    private readonly Game _game;
    private readonly GameConsoleOutput _consoleOutput;

    public GameContext(Game game, GameConsoleOutput consoleOutput)
    {
        _game = game;
        _consoleOutput = consoleOutput;
    }
}