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

public class AddStructureNodeTreeCommand(
    IDocumentStructureNodeMapper mapper,
    DbContextOptions<DocumentDomainDbContext> dbContextOptions,
    IValidator<DocumentStructureNodeInput> validator,
    ILogger<AddStructureNodeTreeCommand> logger) : IAddStructureNodeTreeCommand
{
    public async Task AddTreeAsync(
        long documentId,
        DocumentStructureNodeInput structureNodeInput,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await AddNewRootNodeBusinessLogicAsync(documentId, structureNodeInput, cancellationToken)
                .ConfigureAwait(false);
        }
        catch (ValidationException e)
        {
            throw new InvalidArgumentCommandException(Errors.InvalidInput, e);
        }
        catch (OperationCanceledException e)
        {
            throw new OperationCancelledCommandException(Errors.OperationCancelled, e);
        }
        catch (Exception e)
        {
            throw new UnknownErrorCommandException(Errors.UnexpectedError, e);
        }
    }

    private async Task AddNewRootNodeBusinessLogicAsync(
        long documentId,
        DocumentStructureNodeInput structureNodeInput,
        CancellationToken cancellationToken = default)
    {
        OverWriteRootNode(structureNodeInput);
        OverwriteStructureNodesDocumentIdValue(structureNodeInput, documentId);
        await ValidateProvidedInput(documentId, structureNodeInput, cancellationToken).ConfigureAwait(false);
        DocumentStructureNode documentStructureNode = mapper.MapStructureNodeInputToStructureNode(structureNodeInput);
        await AddTreeAsyncDatabaseOperation(documentStructureNode, cancellationToken).ConfigureAwait(false);
    }

    private async Task AddTreeAsyncDatabaseOperation(
        DocumentStructureNode documentStructureNode,
        CancellationToken cancellationToken = default)
    {
        await using DocumentDomainDbContext ctx = new DocumentDomainDbContext(dbContextOptions);
        await ctx.DocumentStructureNodes.AddAsync(documentStructureNode, cancellationToken).ConfigureAwait(false);
        await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    private void OverWriteRootNode(DocumentStructureNodeInput input)
    {
        input.IsRootNode = 1;
    }

    private void OverwriteStructureNodesDocumentIdValue(DocumentStructureNodeInput structureNodeInput, long documentId)
    {
        structureNodeInput.DocumentId = documentId;
    }

    private async Task ValidateProvidedInput(
        long documentId,
        DocumentStructureNodeInput structureNodeInput,
        CancellationToken cancellationToken = default)
    {
        const long notAllowedValue = 0;
        if (documentId == notAllowedValue)
        {
            string m = $"{nameof(documentId)} cannot be {notAllowedValue}";
            throw new InvalidArgumentCommandException(m);
        }

        if (structureNodeInput is null)
        {
            string m = $"{nameof(structureNodeInput)} must not be null";
            throw new InvalidArgumentCommandException(m);
        }

        // todo: make the validator in a way it validates every item in the tree
        await validator.ValidateAsync(structureNodeInput, o =>
        {
            o.IncludeRuleSets(Common.Validators.Operations.Add);
            o.ThrowOnFailures();
        }, cancellationToken);
    }
}