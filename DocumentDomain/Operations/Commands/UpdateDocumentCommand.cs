#region

using Common.Commands;
using Common.Commands.Exceptions;
using Common.Validators;
using DocumentDomain.Contracts;
using EncyclopediaGalactica.Backend.ApplicationDomain.Infrastructure.Database;
using EncyclopediaGalactica.BusinessLogic.Mappers;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

#endregion

namespace EncyclopediaGalactica.BusinessLogic.Commands.Document;

public class UpdateDocumentCommand(
    IDocumentMapper documentMapper,
    IDocumentInputMapper documentInputMapper,
    IValidator<DocumentInput> documentInputValidator,
    DbContextOptions<DocumentDomainDbContext> dbContextOptions) : IUpdateDocumentCommand
{
    /// <inheritdoc />
    public async Task UpdateAsync(DocumentInput modifiedInput,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await UpdateBusinessLogicAsync(modifiedInput, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e) when (e is DbUpdateException
                                      or ValidationException
                                      or ArgumentNullException)
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
        catch (InvalidOperationException e)
        {
            throw new NoSuchItemCommandException(
                Errors.NoSuchItem,
                e);
        }
        catch (Exception e) when (e is DbUpdateConcurrencyException
                                      or not null)
        {
            throw new UnknownErrorCommandException(
                Errors.UnexpectedError,
                e);
        }
    }

    private async Task UpdateBusinessLogicAsync(
        DocumentInput modifiedInput,
        CancellationToken cancellationToken = default)
    {
        await ValidateUpdateAsyncInput(modifiedInput).ConfigureAwait(false);
        Entities.Document mappedDocument = documentInputMapper.MapDocumentInputToDocument(modifiedInput);
        await UpdateAsyncDatabaseOperation(mappedDocument, cancellationToken).ConfigureAwait(false);
    }

    private async Task UpdateAsyncDatabaseOperation(Entities.Document documentInput,
        CancellationToken cancellationToken = default)
    {
        await using (DocumentDomainDbContext ctx = new DocumentDomainDbContext(dbContextOptions))
        {
            Entities.Document toBeModified = await ctx.Documents
                .FirstAsync(f => f.Id == documentInput.Id, cancellationToken)
                .ConfigureAwait(false);
            Modify(toBeModified, documentInput);
            // any tree belongs to Document will be managed at their own commands
            ctx.Entry(toBeModified).State = EntityState.Modified;
            await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }

    private void Modify(Entities.Document toBeModified, Entities.Document documentInput)
    {
        toBeModified.Name = documentInput.Name;
        toBeModified.Description = documentInput.Description;
        toBeModified.Uri = documentInput.Uri;
    }

    private async Task ValidateUpdateAsyncInput(DocumentInput modifiedInput)
    {
        if (modifiedInput is null)
        {
            string m = $"{nameof(modifiedInput)} cannot be null";
            throw new ArgumentNullException(m);
        }

        await documentInputValidator.ValidateAsync(modifiedInput, o =>
        {
            o.IncludeRuleSets(Operations.Delete);
            o.ThrowOnFailures();
        });
    }
}