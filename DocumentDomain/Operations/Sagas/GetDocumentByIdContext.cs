namespace DocumentDomain.Operations.Sagas;

using Common.Sagas;

public class GetDocumentByIdContext : ISagaContextWithPayload<long>
{
    public long Payload { get; set; }
}