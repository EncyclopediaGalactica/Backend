using DocumentDomain.Contracts;
using EncyclopediaGalactica.BusinessLogic.Entities;

namespace EncyclopediaGalactica.BusinessLogic.Mappers;

public class DocumentInputMapper : IDocumentInputMapper
{
    /// <inheritdoc />
    public Document MapDocumentInputToDocument(DocumentInput input)
    {
        return new Document
        {
            Id = input.Id,
            Name = input.Name,
            Description = input.Description,
            Uri = input?.Uri
        };
    }
}