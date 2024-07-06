#region

using Common.Commands;
using Common.Commands.Exceptions;
using DocumentDomain.Contracts;
using DocumentDomain.Entity;
using DocumentDomain.Infrastructure.Database;
using DocumentDomain.Infrastructure.Mappers;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

#endregion

namespace DocumentDomain.Operations.Commands;

public class AddDocumentCommand(
    IDocumentMapper documentMapper,
    IDocumentInputMapper documentInputMapper,
    IValidator<DocumentInput> documentInputValidator,
    DbContextOptions<DocumentDomainDbContext> dbContextOptions,
    ILogger<AddDocumentCommand> logger) : IAddDocumentCommand
{
    /// <inheritdoc />
    public async Task<long> AddAsync(DocumentInput inputInput,
        CancellationToken cancellationToken = default)
    {
        try
        {
            return await AddBusinessLogicAsync(inputInput, cancellationToken);
        }
        catch (Exception e) when (e is ArgumentNullException
                                      or ValidationException
                                      or DbUpdateException)
        {
            throw new InvalidArgumentCommandException(
                Errors.InvalidInput,
                e);
        }
        catch (Exception e) when (e is OperationCanceledException)
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

    private async Task<long> AddBusinessLogicAsync(DocumentInput input,
        CancellationToken cancellationToken)
    {
        await ValidationDocumentInputForAdding(input);
        Document document = documentInputMapper.MapDocumentInputToDocument(input);

        Document result = await AddAsyncDatabaseOperation(document, cancellationToken).ConfigureAwait(false);
        return result.Id;
    }

    private async Task<Document> AddAsyncDatabaseOperation(
        Document document,
        CancellationToken cancellationToken = default)
    {
        await using DocumentDomainDbContext ctx = new DocumentDomainDbContext(dbContextOptions);
        await ctx.Documents.AddAsync(document, cancellationToken).ConfigureAwait(false);
        await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        logger.LogDebug("Newly created {EntityName} id value: {IdValue}", nameof(Document), document.Id);

        return document;
    }

    private async Task ValidationDocumentInputForAdding(DocumentInput input)
    {
        ArgumentNullException.ThrowIfNull(input);

        await documentInputValidator.ValidateAsync(input, options =>
        {
            options.IncludeRuleSets(Common.Validators.Operations.Add);
            options.ThrowOnFailures();
        });
    }
}