using DocumentDomain.Contracts;
using DocumentDomain.Entity;

namespace DocumentDomain.Infrastructure.Mappers;

public interface IDocumentInputMapper
{
    /// <summary>
    ///     Maps <see cref="DocumentInput" /> to <see cref="Document" />
    /// </summary>
    /// <param name="input">the input dto</param>
    /// <returns><see cref="Document" /> object</returns>
    Document MapDocumentInputToDocument(DocumentInput input);
}