namespace DocumentDomain.Operations.Commands;

using Common.Commands;
using EncyclopediaGalactica.BusinessLogic.Contracts;
using FluentValidation;
using Infrastructure.Database;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

public class GetDocumentTypeByIdCommand(
    IDocumentTypeMapper documentTypeMapper,
    DbContextOptions<DocumentDomainDbContext> dbContextOptions) : IGetDocumentTypeByIdCommand
{
    public async Task<DocumentTypeResult> ExecuteAsync(long input, CancellationToken cancellationToken = default)
    {
        try
        {
            return await ExecuteOperationAsync(input, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task<DocumentTypeResult> ExecuteOperationAsync(long id, CancellationToken cancellationToken)
    {
        ValidateInput(id);
        Entity.DocumentType result = await ExecuteDatabaseOperation(id, cancellationToken).ConfigureAwait(false);
        return documentTypeMapper.ToDocumentTypeResult(result);
    }

    private async Task<Entity.DocumentType> ExecuteDatabaseOperation(long id, CancellationToken cancellationToken)
    {
        await using DocumentDomainDbContext ctx = new(dbContextOptions);
        return await ctx.DocumentTypes.FirstAsync(p => p.Id == id, cancellationToken).ConfigureAwait(false);
    }

    private void ValidateInput(long id)
    {
        if (id > 0)
        {
            string msg = $"{nameof(DocumentTypeInput)} Id value cannot be be smaller than 1.";
            throw new ValidationException(msg);
        }
    }
}

public interface IGetDocumentTypeByIdCommand : IHaveInputAndResultCommand<long, DocumentTypeResult>
{
}