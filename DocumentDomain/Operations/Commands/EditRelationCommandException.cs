using System.Runtime.Serialization;

namespace DocumentDomain.Operations.Commands;

public class EditRelationCommandException : Exception
{
    public EditRelationCommandException()
    {
    }

    protected EditRelationCommandException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public EditRelationCommandException(string? message) : base(message)
    {
    }

    public EditRelationCommandException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}