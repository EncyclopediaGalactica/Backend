namespace DocumentDomain.Operations.Sagas;

using Common.Sagas;
using EncyclopediaGalactica.BusinessLogic.Contracts;

public class AddDocumentSagaContext : ISagaContextWithPayload<DocumentInput>
{
    public DocumentInput Payload { get; set; } = new DocumentInput();
}