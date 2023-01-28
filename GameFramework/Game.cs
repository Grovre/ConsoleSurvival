using GameInterfaces.Exceptions;

namespace GameFramework;

public abstract class Game
{
    public bool HasStarted { get; private set; }
    public bool IsRunning { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }

    protected Game()
    {
        HasStarted = false;
        IsRunning = false;
        StartTime = DateTime.UnixEpoch;
        EndTime = DateTime.UnixEpoch;
    }

    public void Start()
    {
        if (HasStarted)
            throw new GameAlreadyStartedException
                ("Tried starting a game that has already been started");
        
        StartTime = DateTime.Now;
        HasStarted = true;
        IsRunning = true;
        OnStart();
    }

    public void Stop()
    {
        if (!HasStarted)
            throw new GameNotStartedException
                ("Tried stopping a game that hasn't started");
            
        if (HasStarted && !IsRunning)
            throw new GameAlreadyStoppedException
                ("Tried stopping a game that has already been stopped");
        
        EndTime = DateTime.Now;
        IsRunning = false;
        OnStop();
    }

    public TimeSpan GetRunningTime()
    {
        if (IsRunning)
            return DateTime.Now - StartTime;
        return EndTime - StartTime;
    }

    protected abstract void OnStart();

    protected abstract void OnStop();
}