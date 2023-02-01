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
    internal CancellationTokenSource cancelLoopToken;
    public nuint IterationCount { get; private set; } = 0;

    public event Action<nuint>? NextIteration;

    public GameLoop(TimeSpan interval)
    {
        _gate = new(1, 1);
        cancelLoopToken = new();
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
        while (!cancelLoopToken.IsCancellationRequested)
        {
            await _gate.WaitAsync();
            NextIteration?.Invoke(IterationCount);
            IterationCount += 1;
        }
    }
}