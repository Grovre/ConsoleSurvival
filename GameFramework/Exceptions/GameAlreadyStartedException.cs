using System.Runtime.Serialization;

namespace GameFramework.Exceptions;

public class GameAlreadyStartedException : Exception
{
    public GameAlreadyStartedException()
    {
    }

    protected GameAlreadyStartedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public GameAlreadyStartedException(string? message) : base(message)
    {
    }

    public GameAlreadyStartedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}