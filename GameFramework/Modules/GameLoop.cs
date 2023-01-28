namespace GameFramework.Modules;

public class GameLoop
{
    private TimeSpan _interval;
    public TimeSpan Interval
    {
        get => _interval;
        set
        {
            _gateTimer.Change(TimeSpan.Zero, value);
            _interval = value;
        }
    }
    private readonly Timer _gateTimer;
    private readonly SemaphoreSlim _gate;
    internal bool ContinueLooping { get; set; }
    public nuint IterationCount { get; private set; } = 0;

    public event Action<nuint>? NextIteration;

    public GameLoop(TimeSpan interval)
    {
        _gate = new(1, 1);
        _gateTimer = new Timer(_ =>
        {
            try
            {
                _gate.Release();
            }
            catch (SemaphoreFullException)
            {
                // Should not throw anything if 
                // semaphore is full
            }
        });
        Interval = interval;
    }

    internal async Task StartAsync()
    {
        ContinueLooping = true;
        while (ContinueLooping)
        {
            await _gate.WaitAsync();
            NextIteration?.Invoke(IterationCount);
            IterationCount += 1;
        }
    }
}