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
        DocumentType toBeRecorded = documentTypeMapper.FromDocumentTypeInput(input);
        DocumentType result = await ExecuteDatabaseOperation(toBeRecorded, cancellationToken).ConfigureAwait(false);
        return documentTypeMapper.ToDocumentTypeResult(result);
    }

    private async Task<DocumentType> ExecuteDatabaseOperation(DocumentType toBeRecorded,
        CancellationToken cancellationToken)
    {
        await using DocumentDomainDbContext ctx = new DocumentDomainDbContext(dbContextOptions);
        ctx.DocumentTypes.Add(toBeRecorded);
        await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return toBeRecorded;
    }

    private void ValidateInput(DocumentTypeInput? input)
    {
        if (input is null)
        {
            throw new ArgumentNullException("Input is null");
        }

        validator.ValidateAndThrow(input);
    }
}

public interface IAddDocumentTypeCommand
{
    Task<DocumentTypeResult> ExecuteCommandAsync(
        DocumentTypeInput input,
        CancellationToken cancellationToken = default);
}