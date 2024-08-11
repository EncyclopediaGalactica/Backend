namespace DocumentDomain.Operations.Scenarios;

using Common.Sagas;

public class GetRelationByIdScenarioContext : IScenarioContextWithPayload<long>
{
    public long Payload { get; set; }
    public Guid CorrelationId { get; set; }
}