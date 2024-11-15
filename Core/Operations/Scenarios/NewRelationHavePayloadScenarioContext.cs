namespace EncyclopediaGalactica.Core.Operations.Scenarios;

using BusinessLogic.Contracts;

using Common.Scenario;

public class NewRelationHavePayloadScenarioContext : IHavePayloadScenarioContext<RelationInput>
{
    public RelationInput Payload { get; set; }
    public Guid CorrelationId { get; set; }
}