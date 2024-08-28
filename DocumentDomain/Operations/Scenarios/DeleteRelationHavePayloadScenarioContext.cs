namespace DocumentDomain.Operations.Scenarios;

using Common.Sagas;

public class DeleteRelationHavePayloadScenarioContext : IHavePayloadScenarioContext<long>
{
    public long Payload { get; set; }
    public Guid CorrelationId { get; set; }
}