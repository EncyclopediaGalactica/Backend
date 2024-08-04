namespace DocumentDomain.Operations.Scenarios.DocumentType;

using Common.Sagas;
using EncyclopediaGalactica.BusinessLogic.Contracts;

public class DeleteDocumentTypeScenarioContext : ISagaContextWithPayload<DocumentTypeInput>
{
    public DocumentTypeInput? Payload { get; set; }
}