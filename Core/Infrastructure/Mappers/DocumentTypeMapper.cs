namespace EncyclopediaGalactica.Core.Infrastructure.Mappers;

using BusinessLogic.Contracts;
using Entity;

public class DocumentTypeMapper : IDocumentTypeMapper
{
    public DocumentTypeResult ToDocumentTypeResult(DocumentType documentType) =>
        new()
        {
            Id          = documentType.Id,
            Name        = documentType.Name,
            Description = documentType.Description,
        };

    public List<DocumentTypeResult> ToDocumentTypeResults(List<DocumentType> documentTYpes)
    {
        List<DocumentTypeResult> result = new();
        documentTYpes.ForEach(i => { result.Add(ToDocumentTypeResult(i)); });
        return result;
    }

    public DocumentType FromDocumentTypeInput(DocumentTypeInput input) =>
        new()
        {
            Id          = input.Id,
            Name        = input.Name,
            Description = input.Description,
        };
}

public interface IDocumentTypeMapper
{
    DocumentTypeResult ToDocumentTypeResult(DocumentType              documentType);
    List<DocumentTypeResult> ToDocumentTypeResults(List<DocumentType> documentTYpes);
    DocumentType FromDocumentTypeInput(DocumentTypeInput              input);
}