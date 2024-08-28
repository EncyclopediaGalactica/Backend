namespace DocumentDomain.Operations.Scenarios.Application;

using EncyclopediaGalactica.BusinessLogic.Contracts;

public class GetApplicationByIdScenarioContext
{
    public Guid CorrelationId { get; set; }
    public ApplicationInput Payload { get; set; }
}