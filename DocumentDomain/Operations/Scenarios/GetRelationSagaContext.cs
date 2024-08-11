namespace DocumentDomain.Operations.Scenarios;

using Common.Sagas;

public class GetRelationSagaContext : ISagaContext
{
    public Guid CorrelationId { get; set; }
}