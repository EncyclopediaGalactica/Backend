namespace EncyclopediaGalactica.Core.Operations.Scenarios.DocumentType;

using BusinessLogic.Contracts;
using Common.Scenario;

public class DeleteDocumentTypeHavePayloadScenarioContext : IHavePayloadScenarioContext<DocumentTypeInput>
{
    public DocumentTypeInput? Payload { get; set; }
    public Guid CorrelationId { get; set; }
}