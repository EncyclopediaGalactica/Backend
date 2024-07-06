using Common.Sagas;

namespace DocumentDomain.Operations.Sagas;

public class GetRelationByIdSagaContext : ISagaContextWithPayload<long>
{
    public long Payload { get; set; }
}