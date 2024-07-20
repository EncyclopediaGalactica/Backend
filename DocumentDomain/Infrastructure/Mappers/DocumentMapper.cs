namespace DocumentDomain.Infrastructure.Mappers;

using Contracts;
using Entity;

/// <inheritdoc />
public class DocumentMapper : IDocumentMapper
{
    /// <inheritdoc />
    public List<DocumentResult> MapDocumentsToDocumentResults(List<Document> l)
    {
        var resultList = new List<DocumentResult>();
        if (!l.Any()) return resultList;

        foreach (var item in l) resultList.Add(MapDocumentToDocumentResult(item));

        return resultList;
    }

    /// <inheritdoc />
    public DocumentResult MapDocumentToDocumentResult(Document document)
    {
        return new DocumentResult
        {
            Id = document.Id,
            Name = document.Name,
            Description = document.Description,
            Uri = document?.Uri
        };
    }
}