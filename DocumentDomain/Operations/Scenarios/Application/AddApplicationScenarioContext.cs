namespace EncyclopediaGalactica.DocumentDomain.Operations.Scenarios.Application;

using Common.Sagas;
using EncyclopediaGalactica.BusinessLogic.Contracts;

public class AddApplicationScenarioContext : IHavePayloadScenarioContext<ApplicationInput>
{
    public ApplicationInput? Payload { get; set; }
    public Guid CorrelationId { get; set; }
}