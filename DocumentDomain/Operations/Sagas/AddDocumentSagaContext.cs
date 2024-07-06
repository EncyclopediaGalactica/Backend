#region

using Common.Sagas;
using DocumentDomain.Contracts;

#endregion

namespace DocumentDomain.Operations.Sagas;

public class AddDocumentSagaContext : ISagaContextWithPayload<DocumentInput>
{
    public DocumentInput Payload { get; set; } = new DocumentInput();
}