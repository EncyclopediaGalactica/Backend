namespace EncyclopediaGalactica.DocumentDomain.Operations.Scenarios.Application;

using Common.Scenario;
using EncyclopediaGalactica.BusinessLogic.Contracts;

public class UpdateApplicationScenarioContext : IHavePayloadScenarioContext<ApplicationInput>
{
    public Guid CorrelationId { get; set; }
    public ApplicationInput? Payload { get; set; }
}