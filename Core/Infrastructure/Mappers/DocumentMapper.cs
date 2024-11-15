namespace EncyclopediaGalactica.Core.Infrastructure.Mappers;

using BusinessLogic.Contracts;

using Entity;

/// <inheritdoc />
public class DocumentMapper : IDocumentMapper
{
    /// <inheritdoc />
    public List<DocumentResult> MapDocumentsToDocumentResults(List<Document> l)
    {
        List<DocumentResult>? resultList = new();
        if (!l.Any())
        {
            return resultList;
        }

        foreach (Document? item in l)
        {
            resultList.Add(MapDocumentToDocumentResult(item));
        }

        return resultList;
    }

    /// <inheritdoc />
    public DocumentResult MapDocumentToDocumentResult(Document document) =>
        new()
        {
            Id          = document.Id,
            Name        = document.Name,
            Description = document.Description,
            Uri         = document?.Uri,
        };
}