namespace DocumentDomain.Operations.Commands.DocumentType;

using Common.Commands;
using EncyclopediaGalactica.BusinessLogic.Contracts;
using Entity;
using FluentValidation;
using Infrastructure.Database;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using Scenarios.DocumentType;

public class DeleteDocumentTypeCommand(
    IDocumentTypeMapper documentTypeMapper,
    DeleteDocumentTypeScenarioInputValidator validator,
    DbContextOptions<DocumentDomainDbContext> dbContextOptions) : IDeleteDocumentTypeCommand
{
    public async Task ExecuteAsync(
        DocumentTypeInput? input,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await ExecuteCommandAsync(input, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task ExecuteCommandAsync(
        DocumentTypeInput? input,
        CancellationToken cancellationToken)
    {
        await Validate(input, cancellationToken);
        await ExecuteDatabaseOperation(input, cancellationToken).ConfigureAwait(false);
    }

    private async Task ExecuteDatabaseOperation(
        DocumentTypeInput? input,
        CancellationToken cancellationToken)
    {
        await using DocumentDomainDbContext ctx = new(dbContextOptions);
        DocumentType toBeDeleted = await ctx.DocumentTypes.FirstAsync(
            p => p.Id == input!.Id, cancellationToken).ConfigureAwait(false);
        ctx.Entry(toBeDeleted).State = EntityState.Deleted;
        await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    private async Task Validate(
        DocumentTypeInput? input,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(input);
        await validator.ValidateAndThrowAsync(input, cancellationToken).ConfigureAwait(false);
    }
}

public interface IDeleteDocumentTypeCommand : IHaveInputCommand<DocumentTypeInput>
{
}