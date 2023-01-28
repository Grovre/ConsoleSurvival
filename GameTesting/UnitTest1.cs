using ConsoleGame;
using GameInterfaces.Exceptions;

namespace GameTesting;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        // No setup needed yet
    }

    /* TODO: Fix game initializations
    [Test]
    public void GameStartStopTests()
    {
        Assert.Throws<GameAlreadyStartedException>(() =>
        {
            var game = new ConsoleSurvivalGame();
            game.Start();
            game.Start();
        });
        Assert.Throws<GameAlreadyStoppedException>(() =>
        {
            var game = new ConsoleSurvivalGame();
            game.Start();
            game.Stop();
            game.Stop();
        });
        Assert.Throws<GameNotStartedException>(() =>
        {
            var game = new ConsoleSurvivalGame();
            game.Stop();
        });
    }
    */
}