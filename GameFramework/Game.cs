using GameFramework.Exceptions;
using GameFramework.Modules;

namespace GameFramework;

public abstract class Game
{
    public bool HasStarted { get; private set; }
    public bool IsRunning { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }

    public GameConsoleOutput ConsoleOutput { get; set; }
    public GameLoop Loop { get; }
    public PromptInput PromptSystem { get; }

    public event Action? StartedGame;
    public event Action? StoppedGame;

    protected Game(TextWriter outputWriter, TextReader inputReader, TimeSpan gameLoopInterval)
    {
        HasStarted = false;
        IsRunning = false;
        StartTime = DateTime.UnixEpoch;
        EndTime = DateTime.UnixEpoch;
        ConsoleOutput = new(outputWriter);
        Loop = new(gameLoopInterval);
        PromptSystem = new(outputWriter, inputReader);
    }

    public Task Start()
    {
        if (HasStarted)
            throw new GameAlreadyStartedException
                ("Tried starting a game that has already been started");
        
        StartTime = DateTime.Now;
        HasStarted = true;
        IsRunning = true;
        StartedGame?.Invoke();
        return Loop.StartAsync();
    }

    public void Stop()
    {
        switch (HasStarted)
        {
            case false:
                throw new GameNotStartedException
                    ("Tried stopping a game that hasn't started");
            case true when !IsRunning:
                throw new GameAlreadyStoppedException
                    ("Tried stopping a game that has already been stopped");
        }

        Loop.cancelLoopToken.Cancel(false);
        EndTime = DateTime.Now;
        IsRunning = false;
        StoppedGame?.Invoke();
    }

    public TimeSpan GetRunningTime()
    {
        if (IsRunning)
            return DateTime.Now - StartTime;
        return EndTime - StartTime;
    }
}