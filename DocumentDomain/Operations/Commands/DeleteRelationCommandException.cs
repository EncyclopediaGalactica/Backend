using System.Runtime.Serialization;

namespace DocumentDomain.Operations.Commands;

public class DeleteRelationCommandException : Exception
{
    public DeleteRelationCommandException()
    {
    }

    protected DeleteRelationCommandException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public DeleteRelationCommandException(string? message) : base(message)
    {
    }

    public DeleteRelationCommandException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}