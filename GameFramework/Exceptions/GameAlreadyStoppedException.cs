using System.Runtime.Serialization;

namespace GameFramework.Exceptions;

public class GameAlreadyStoppedException : Exception
{
    public GameAlreadyStoppedException()
    {
    }

    protected GameAlreadyStoppedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public GameAlreadyStoppedException(string? message) : base(message)
    {
    }

    public GameAlreadyStoppedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}