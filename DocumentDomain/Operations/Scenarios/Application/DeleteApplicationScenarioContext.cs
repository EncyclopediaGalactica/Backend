namespace EncyclopediaGalactica.DocumentDomain.Operations.Scenarios.Application;

using Common.Sagas;
using EncyclopediaGalactica.BusinessLogic.Contracts;

public class DeleteApplicationScenarioContext : IHavePayloadScenarioContext<ApplicationInput>
{
    public Guid CorrelationId { get; set; }
    public ApplicationInput? Payload { get; set; }
}