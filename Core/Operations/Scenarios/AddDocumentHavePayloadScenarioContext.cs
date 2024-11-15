namespace EncyclopediaGalactica.Core.Operations.Scenarios;

using BusinessLogic.Contracts;
using Common.Scenario;

public class AddDocumentHavePayloadScenarioContext : IHavePayloadScenarioContext<DocumentInput>
{
    public DocumentInput Payload { get; set; } = new();
    public Guid CorrelationId { get; set; }
}