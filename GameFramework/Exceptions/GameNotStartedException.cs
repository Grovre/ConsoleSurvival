using System.Runtime.Serialization;

namespace GameFramework.Exceptions;

public class GameNotStartedException : Exception
{
    public GameNotStartedException()
    {
    }

    protected GameNotStartedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public GameNotStartedException(string? message) : base(message)
    {
    }

    public GameNotStartedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}