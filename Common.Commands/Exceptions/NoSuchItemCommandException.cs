#region

using System.Runtime.Serialization;

#endregion

namespace Common.Commands.Exceptions;

public class NoSuchItemCommandException : Exception
{
    public NoSuchItemCommandException()
    {
    }

    protected NoSuchItemCommandException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public NoSuchItemCommandException(string? message) : base(message)
    {
    }

    public NoSuchItemCommandException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}