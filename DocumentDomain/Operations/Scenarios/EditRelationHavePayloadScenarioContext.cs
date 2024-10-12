namespace EncyclopediaGalactica.DocumentDomain.Operations.Scenarios;

using Common.Scenario;
using EncyclopediaGalactica.BusinessLogic.Contracts;

public class EditRelationHavePayloadScenarioContext : IHavePayloadScenarioContext<RelationInput>
{
    public RelationInput Payload { get; set; }
    public Guid CorrelationId { get; set; }
}