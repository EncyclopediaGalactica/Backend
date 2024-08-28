namespace DocumentDomain.Operations.Scenarios.DocumentType;

using Common.Sagas;
using EncyclopediaGalactica.BusinessLogic.Contracts;

public class UpdateDocumentTypeScenarioContext : IHavePayloadScenarioContext<DocumentTypeInput>
{
    public DocumentTypeInput? Payload { get; set; }
    public Guid CorrelationId { get; set; }
}