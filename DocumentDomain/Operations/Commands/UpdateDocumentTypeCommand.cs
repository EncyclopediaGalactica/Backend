namespace DocumentDomain.Operations.Commands;

using EncyclopediaGalactica.BusinessLogic.Contracts;
using Entity;
using FluentValidation;
using Infrastructure.Database;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

public class UpdateDocumentTypeCommand(
    IValidator<DocumentTypeInput> validator,
    IDocumentTypeMapper mapper,
    DbContextOptions<DocumentDomainDbContext> dbContextOptions) : IUpdateDocumentTypeCommand
{
    public async Task<DocumentTypeResult> ExecuteAsync(
        DocumentTypeInput input,
        CancellationToken cancellationToken = default)
    {
        try
        {
            return await ExecuteCommandAsync(input, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task<DocumentTypeResult> ExecuteCommandAsync(DocumentTypeInput input,
        CancellationToken cancellationToken)
    {
        ValidateInput(input);
        DocumentType modification = mapper.FromDocumentTypeInput(input);
        DocumentType modified = await ExecuteDatabaseOperationAsync(modification, cancellationToken).ConfigureAwait(false);
        return mapper.ToDocumentTypeResult(modified);
    }

    private void ValidateInput(DocumentTypeInput input)
    {
        throw new NotImplementedException();
    }
}

public interface IUpdateDocumentTypeCommand
{
    Task<DocumentTypeResult> ExecuteAsync(DocumentTypeInput input, CancellationToken cancellationToken = default);
}