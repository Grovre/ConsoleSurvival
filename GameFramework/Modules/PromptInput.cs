namespace GameFramework.Modules;

public class PromptInput
{
    private TextWriter _writer;
    private TextReader _reader;

    public PromptInput(TextWriter writer, TextReader reader)
    {
        _writer = writer;
        _reader = reader;
    }

    public string? Prompt(string format, params object?[] args)
    {
        var prompt = string.Format(format, args);
        _writer.WriteLine(prompt);
        return _reader.ReadLine();
    }
}