using GameFramework.Modules;
using GameInterfaces.Exceptions;

namespace GameFramework;

public abstract class Game
{
    public bool HasStarted { get; private set; }
    public bool IsRunning { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }

    public GameConsoleOutput ConsoleOutput { get; set; }
    public GameLoop Loop { get; }
    
    private readonly TimeSpan? _timeout;

    public event Action? StartedGame;
    public event Action? StoppedGame;

    protected Game(TextWriter consoleOutputWriter, TimeSpan gameLoopInterval, bool loopGameAsync = false)
    {
        HasStarted = false;
        IsRunning = false;
        StartTime = DateTime.UnixEpoch;
        EndTime = DateTime.UnixEpoch;
        _loopAsync = loopGameAsync;
        ConsoleOutput = new(consoleOutputWriter);
        Loop = new(gameLoopInterval);
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
        
        Loop.ContinueLooping = false;
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