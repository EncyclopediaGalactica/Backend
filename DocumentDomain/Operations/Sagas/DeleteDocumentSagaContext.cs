using Common.Sagas;

namespace DocumentDomain.Operations.Sagas;

public class DeleteDocumentSagaContext : ISagaContextWithPayload<Int64>
{
    public Int64 Payload { get; set; }
}