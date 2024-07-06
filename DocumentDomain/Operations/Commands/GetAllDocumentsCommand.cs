#region

using Common.Commands;
using Common.Commands.Exceptions;
using DocumentDomain.Contracts;
using EncyclopediaGalactica.Backend.ApplicationDomain.Infrastructure.Database;
using EncyclopediaGalactica.BusinessLogic.Mappers;
using Microsoft.EntityFrameworkCore;

#endregion

namespace EncyclopediaGalactica.BusinessLogic.Commands.Document;

public class GetAllDocumentsCommand(
    IDocumentMapper documentMapper,
    DbContextOptions<DocumentDomainDbContext> dbContextOptions) : IGetAllDocumentsCommand
{
    /// <inheritdoc />
    public async Task<List<DocumentResult>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return await GetAllBusinessLogicAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException e)
        {
            string m = $"{nameof(GetAllDocumentsCommand)} execution has been cancelled.";
            throw new OperationCancelledCommandException(m, e);
        }
        catch (Exception e)
        {
            throw new UnknownErrorCommandException(
                Errors.UnexpectedError,
                e);
        }
    }

    private async Task<List<DocumentResult>> GetAllBusinessLogicAsync(CancellationToken cancellationToken = default)
    {
        List<Entities.Document> result =
            await GetAllDocumentsAsyncDatabaseOperation(cancellationToken).ConfigureAwait(false);
        return documentMapper.MapDocumentsToDocumentResults(result);
    }

    private async Task<List<Entities.Document>> GetAllDocumentsAsyncDatabaseOperation(
        CancellationToken cancellationToken = default)
    {
        await using DocumentDomainDbContext ctx = new DocumentDomainDbContext(dbContextOptions);
        return await ctx.Documents.ToListAsync(cancellationToken).ConfigureAwait(false);
    }
}