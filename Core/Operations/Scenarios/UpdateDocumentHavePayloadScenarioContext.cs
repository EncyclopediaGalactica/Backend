namespace EncyclopediaGalactica.Core.Operations.Scenarios;

using BusinessLogic.Contracts;

using Common.Scenario;

public class UpdateDocumentHavePayloadScenarioContext : IHavePayloadScenarioContext<DocumentInput>
{
    public DocumentInput Payload { get; set; }
    public Guid CorrelationId { get; set; }
}