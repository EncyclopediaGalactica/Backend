namespace DocumentDomain.Operations.Scenarios;

using Common.Sagas;

public class DeleteDocumentSagaContext : ISagaContextWithPayload<Int64>
{
    public Int64 Payload { get; set; }
}