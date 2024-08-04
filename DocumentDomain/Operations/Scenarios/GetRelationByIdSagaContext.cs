namespace DocumentDomain.Operations.Scenarios;

using Common.Sagas;

public class GetRelationByIdSagaContext : ISagaContextWithPayload<long>
{
    public long Payload { get; set; }
}