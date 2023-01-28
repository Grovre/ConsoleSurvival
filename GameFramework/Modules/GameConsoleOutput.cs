namespace GameFramework.Modules;

public class GameConsoleOutput : IDisposable
{
    private readonly TextWriter _writer;

    public event Action<string?>? TextWritten;
    public event Action? WriterDisposed;
    public event Action? WriterClosed;
    public event Action? WriterFlushed;

    public GameConsoleOutput(TextWriter writer)
    {
        _writer = writer;
    }

    #region DelegatedMethods

    public void Close()
    {
        WriterClosed?.Invoke();
        _writer.Close();
    }

    public void Flush()
    {
        WriterFlushed?.Invoke();
        _writer.Flush();
    }

    public void Dispose()
    {
        _writer.Dispose();
        GC.SuppressFinalize(this);
        WriterDisposed?.Invoke();
    }

    public void Write(object? value)
    {
        var str = value?.ToString();
        _writer.Write(str);
        TextWritten?.Invoke(str);
    }

    public void WriteLine(object? value)
    {
        var str = value?.ToString();
        _writer.WriteLine(str);
        TextWritten?.Invoke(str);
    }
    
    #endregion
}