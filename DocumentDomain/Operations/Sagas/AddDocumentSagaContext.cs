#region

#endregion

namespace DocumentDomain.Operations.Sagas;

using Common.Sagas;
using Contracts;

public class AddDocumentSagaContext : ISagaContextWithPayload<DocumentInput>
{
    public DocumentInput Payload { get; set; } = new DocumentInput();
}