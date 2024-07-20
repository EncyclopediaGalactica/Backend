#region

#endregion

namespace DocumentDomain.Operations.Sagas;

using Common.Sagas;
using Contracts;

public class UpdateDocumentSagaContext : ISagaContextWithPayload<DocumentInput>
{
    public DocumentInput Payload { get; set; }
}