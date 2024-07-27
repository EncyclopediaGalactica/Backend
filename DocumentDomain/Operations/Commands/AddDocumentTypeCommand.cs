namespace DocumentDomain.Operations.Commands;

using EncyclopediaGalactica.BusinessLogic.Contracts;
using Entity;
using FluentValidation;
using Infrastructure.Database;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

public class AddDocumentTypeCommand(
    IValidator<DocumentTypeInput> validator,
    IDocumentTypeMapper documentTypeMapper,
    DbContextOptions<DocumentDomainDbContext> dbContextOptions) : IAddDocumentTypeCommand
{
    public async Task<DocumentTypeResult> ExecuteCommandAsync(
        DocumentTypeInput? input,
        CancellationToken cancellationToken = default)
    {
        try
        {
            return await ExecuteAsync(input, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task<DocumentTypeResult> ExecuteAsync(DocumentTypeInput? input, CancellationToken cancellationToken)
    {
        ValidateInput(input);
        Entity.DocumentType toBeRecorded = documentTypeMapper.FromDocumentTypeInput(input);
        Entity.DocumentType result =
            await ExecuteDatabaseOperation(toBeRecorded, cancellationToken).ConfigureAwait(false);
        return documentTypeMapper.ToDocumentTypeResult(result);
    }

    private async Task<Entity.DocumentType> ExecuteDatabaseOperation(Entity.DocumentType toBeRecorded,
        CancellationToken cancellationToken)
    {
        await using DocumentDomainDbContext ctx = new DocumentDomainDbContext(dbContextOptions);
        ctx.DocumentTypes.Add(toBeRecorded);
        await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return toBeRecorded;
    }

    private void ValidateInput(DocumentTypeInput? input)
    {
        ArgumentNullException.ThrowIfNull(input);

        validator.ValidateAndThrow(input);
    }
}

/// <summary>
///     Add Document Type Command interface.
///     <remarks>
///         It provides a single method to execute the command adding a new <see cref="DocumentType" /> entity to the
///         system.
///     </remarks>
/// </summary>
public interface IAddDocumentTypeCommand
{
    Task<DocumentTypeResult> ExecuteCommandAsync(
        DocumentTypeInput? input,
        CancellationToken cancellationToken = default);
}