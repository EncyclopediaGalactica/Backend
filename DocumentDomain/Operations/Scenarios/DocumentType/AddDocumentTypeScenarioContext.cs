namespace DocumentDomain.Operations.Scenarios.DocumentType;

using Common.Sagas;
using EncyclopediaGalactica.BusinessLogic.Contracts;

public class AddDocumentTypeScenarioContext : IScenarioContextWithPayload<DocumentTypeInput>
{
    public DocumentTypeInput? Payload { get; set; }
    public Guid CorrelationId { get; set; }
}