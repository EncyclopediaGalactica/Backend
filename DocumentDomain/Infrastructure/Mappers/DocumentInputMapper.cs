namespace DocumentDomain.Infrastructure.Mappers;

using EncyclopediaGalactica.BusinessLogic.Contracts;
using Entity;

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