using Common.Sagas;

namespace DocumentDomain.Operations.Sagas;

public class GetDocumentByIdContext : ISagaContextWithPayload<long>
{
    public long Payload { get; set; }
}