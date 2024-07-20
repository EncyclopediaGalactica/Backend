namespace DocumentDomain.Operations.Sagas;

using Common.Sagas;

public class GetRelationByIdSagaContext : ISagaContextWithPayload<long>
{
    public long Payload { get; set; }
}