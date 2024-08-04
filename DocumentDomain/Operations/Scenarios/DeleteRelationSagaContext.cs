namespace DocumentDomain.Operations.Scenarios;

using Common.Sagas;

public class DeleteRelationSagaContext : ISagaContextWithPayload<long>
{
    public long Payload { get; set; }
}