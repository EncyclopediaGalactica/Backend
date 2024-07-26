namespace DocumentDomain.Operations.Sagas;

using Common.Sagas;
using EncyclopediaGalactica.BusinessLogic.Contracts;

public class UpdateDocumentSagaContext : ISagaContextWithPayload<DocumentInput>
{
    public DocumentInput Payload { get; set; }
}