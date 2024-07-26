namespace DocumentDomain.Operations.Sagas;

using Common.Sagas;
using EncyclopediaGalactica.BusinessLogic.Contracts;

public class AddDocumentTypeSagaContext : ISagaContextWithPayload<DocumentTypeInput>
{
    public DocumentTypeInput? Payload { get; set; }
}