namespace EncyclopediaGalactica.Core.Infrastructure.Mappers;

using BusinessLogic.Contracts;

using Entity;

public class DocumentInputMapper : IDocumentInputMapper
{
    /// <inheritdoc />
    public Document MapDocumentInputToDocument(DocumentInput input) =>
        new()
        {
            Id          = input.Id,
            Name        = input.Name,
            Description = input.Description,
            Uri         = input?.Uri,
        };
}