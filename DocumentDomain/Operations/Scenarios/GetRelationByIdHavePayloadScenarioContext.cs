namespace EncyclopediaGalactica.DocumentDomain.Operations.Scenarios;

using Common.Sagas;

public class GetRelationByIdHavePayloadScenarioContext : IHavePayloadScenarioContext<long>
{
    public long Payload { get; set; }
    public Guid CorrelationId { get; set; }
}