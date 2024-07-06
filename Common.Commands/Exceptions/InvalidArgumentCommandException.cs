using System.Runtime.Serialization;

namespace Common.Commands.Exceptions;

public class InvalidArgumentCommandException : Exception
{
    public InvalidArgumentCommandException()
    {
    }

    protected InvalidArgumentCommandException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public InvalidArgumentCommandException(string? message) : base(message)
    {
    }

    public InvalidArgumentCommandException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}