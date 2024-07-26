namespace DocumentDomain.Operations.Commands;

using EncyclopediaGalactica.BusinessLogic.Contracts;
using Entity;
using Infrastructure.Database;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

public class GetDocumentTypesCommand(
    IDocumentTypeMapper documentTypeMapper,
    DbContextOptions<DocumentDomainDbContext> dbContextOptions) : IGetDocumentTypesCommand
{
    public async Task<List<DocumentTypeResult>> ExecuteAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return await ExecuteOprationAsync().ConfigureAwait(false);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task<List<DocumentTypeResult>> ExecuteOprationAsync()
    {
        List<DocumentType> result = await GetFromDatabase().ConfigureAwait(false);
        return documentTypeMapper.ToDocumentTypeResults(result);
    }

    private async Task<List<DocumentType>> GetFromDatabase()
    {
        using DocumentDomainDbContext ctx = new DocumentDomainDbContext(dbContextOptions);
        return await ctx.DocumentTypes.ToListAsync();
    }
}

public interface IGetDocumentTypesCommand
{
    Task<List<DocumentTypeResult>> ExecuteAsync(CancellationToken cancellationToken = default);
}