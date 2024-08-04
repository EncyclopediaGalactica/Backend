namespace DocumentDomain.Operations.Commands;

using Common.Commands;
using EncyclopediaGalactica.BusinessLogic.Contracts;
using Infrastructure.Database;
using Infrastructure.Mappers;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

/// <summary>
///     Get the list of <see cref="DocumentType" />s command.
/// </summary>
/// <remarks>
///     This command provides a single method Api to retrieve the list of <see cref="DocumentType" /> safely.
/// </remarks>
/// <param name="documentTypeMapper"><see cref="IDocumentTypeMapper" /> implementation.</param>
/// <param name="dbContextOptions"><see cref="DbContextOptions{TContext}" />.</param>
public class GetDocumentTypesCommand(
    IDocumentTypeMapper documentTypeMapper,
    DbContextOptions<DocumentDomainDbContext> dbContextOptions) : IGetDocumentTypesCommand
{
    public async Task<Option<List<DocumentTypeResult>>> ExecuteAsync(CancellationToken cancellationToken = default)
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

    private async Task<Option<List<DocumentTypeResult>>> ExecuteOprationAsync()
    {
        List<Entity.DocumentType> result = await GetFromDatabase().ConfigureAwait(false);
        return documentTypeMapper.ToDocumentTypeResults(result);
    }

    private async Task<List<Entity.DocumentType>> GetFromDatabase()
    {
        using DocumentDomainDbContext ctx = new DocumentDomainDbContext(dbContextOptions);
        return await ctx.DocumentTypes.ToListAsync();
    }
}

public interface IGetDocumentTypesCommand : IHaveResultCommand<List<DocumentTypeResult>>
{
}