using System.Runtime.Serialization;

namespace DocumentDomain.Operations.Commands;

public class GetRelationsCommandException : Exception
{
    public GetRelationsCommandException()
    {
    }

    protected GetRelationsCommandException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public GetRelationsCommandException(string? message) : base(message)
    {
    }

    public GetRelationsCommandException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}