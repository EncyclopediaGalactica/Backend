namespace EncyclopediaGalactica.DocumentDomain.Operations.Scenarios;

using Common.Sagas;
using EncyclopediaGalactica.BusinessLogic.Contracts;

public class NewRelationHavePayloadScenarioContext : IHavePayloadScenarioContext<RelationInput>
{
    public RelationInput Payload { get; set; }
    public Guid CorrelationId { get; set; }
}