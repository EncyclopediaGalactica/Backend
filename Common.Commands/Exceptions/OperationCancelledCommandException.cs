using System.Runtime.Serialization;

namespace Common.Commands.Exceptions;

public class OperationCancelledCommandException : Exception
{
    public OperationCancelledCommandException()
    {
    }

    protected OperationCancelledCommandException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public OperationCancelledCommandException(string? message) : base(message)
    {
    }

    public OperationCancelledCommandException(string? message, Exception? innerException) : base(message,
        innerException)
    {
    }
}