#region

using Common.Commands;
using Common.Commands.Exceptions;
using DocumentDomain.Contracts;
using DocumentDomain.Entity;
using DocumentDomain.Infrastructure.Database;
using DocumentDomain.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

#endregion

namespace DocumentDomain.Operations.Commands;

public class GetDocumentByIdCommand(
    IDocumentMapper documentMapper,
    DbContextOptions<DocumentDomainDbContext> dbContextOptions,
    ILogger<GetDocumentByIdCommand> logger) : IGetDocumentByIdCommand
{
    /// <inheritdoc />
    public async Task<DocumentResult> GetByIdAsync(
        long id,
        CancellationToken cancellationToken = default)
    {
        try
        {
            return await GetByIdBusinessLogicAsync(id, cancellationToken).ConfigureAwait(false);
        }
        catch (InvalidOperationException e)
        {
            throw new NoSuchItemCommandException(
                Errors.NoSuchItem,
                e);
        }
        catch (OperationCanceledException e)
        {
            throw new OperationCancelledCommandException(
                Errors.OperationCancelled,
                e);
        }
        catch (Exception e)
        {
            throw new UnknownErrorCommandException(
                Errors.UnexpectedError,
                e);
        }
    }

    private async Task<DocumentResult> GetByIdBusinessLogicAsync(long id, CancellationToken cancellationToken)
    {
        ValidateInput(id);
        Document result = await GetByIdAsyncDatabaseOperation(id, cancellationToken).ConfigureAwait(false);
        DocumentResult input = documentMapper.MapDocumentToDocumentResult(result);
        return input;
    }

    private async Task<Document> GetByIdAsyncDatabaseOperation(long id,
        CancellationToken cancellationToken = default)
    {
        await using DocumentDomainDbContext ctx = new DocumentDomainDbContext(dbContextOptions);
        return await ctx.Documents.FirstAsync(f => f.Id == id, cancellationToken).ConfigureAwait(false);
    }

    private void ValidateInput(long id)
    {
        logger.LogDebug("Input value: {InputValue}", id);
        const long notAllowedValue = 0;
        if (id == notAllowedValue)
        {
            string m = $"{id} cannot be {notAllowedValue}";
            throw new InvalidArgumentCommandException(m);
        }
    }
}