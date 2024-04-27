namespace EncyclopediaGalactica.BusinessLogic.Commands.Document;

using Database;
using Entities;
using Exceptions;
using Microsoft.EntityFrameworkCore;

public class DeleteDocumentCommand(
    DbContextOptions<DocumentDbContext> dbContextOptions) : IDeleteDocumentCommand
{
    /// <inheritdoc />
    public async Task DeleteAsync(long documentId, CancellationToken cancellationToken = default)
    {
        try
        {
            await DeleteBusinessLogicAsync(documentId, cancellationToken).ConfigureAwait(false);
        }
        catch (InvalidOperationException e)
        {
            throw new NoSuchItemCommandException(
                Errors.Errors.NoSuchItem,
                e);
        }
        catch (OperationCanceledException e)
        {
            throw new OperationCancelledCommandException(
                Errors.Errors.OperationCancelled,
                e);
        }
        catch (DbUpdateException e)
        {
            throw new UnknownErrorCommandException(
                Errors.Errors.UnexpectedError,
                e);
        }
    }

    private async Task DeleteBusinessLogicAsync(long documentId, CancellationToken cancellationToken)
    {
        ValidateDeleteAsyncInput(documentId);
        await DeleteAsyncDatabaseOperation(documentId, cancellationToken).ConfigureAwait(false);
    }

    private async Task DeleteAsyncDatabaseOperation(long documentId, CancellationToken cancellationToken = default)
    {
        await using DocumentDbContext ctx = new DocumentDbContext(dbContextOptions);
        Document toBeDeleted = await ctx.Documents.FirstAsync(f => f.Id == documentId, cancellationToken);
        ctx.Documents.Entry(toBeDeleted).State = EntityState.Deleted;
        await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    private void ValidateDeleteAsyncInput(long documentId)
    {
        long invalidValue = 0;
        if (documentId == invalidValue)
        {
            string m = $"{nameof(documentId)} cannot be {invalidValue}.";
            throw new InvalidArgumentCommandException(m);
        }
    }
}