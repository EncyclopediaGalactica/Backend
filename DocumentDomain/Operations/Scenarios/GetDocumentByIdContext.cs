namespace DocumentDomain.Operations.Scenarios;

using Common.Sagas;

public class GetDocumentByIdContext : ISagaContextWithPayload<long>
{
    public long Payload { get; set; }
}