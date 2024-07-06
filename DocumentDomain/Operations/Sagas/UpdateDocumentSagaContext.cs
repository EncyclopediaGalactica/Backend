#region

using DocumentDomain.Contracts;
using EncyclopediaGalactica.BusinessLogic.Sagas.Interfaces;

#endregion

namespace EncyclopediaGalactica.BusinessLogic.Sagas.Document;

public class UpdateDocumentSagaContext : ISagaContextWithPayload<DocumentInput>
{
    public DocumentInput Payload { get; set; }
}