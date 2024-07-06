using DocumentDomain.Contracts;
using DocumentDomain.Entity;

namespace DocumentDomain.Infrastructure.Mappers;

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