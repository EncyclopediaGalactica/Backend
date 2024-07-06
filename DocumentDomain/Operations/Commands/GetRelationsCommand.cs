#region

using DocumentDomain.Contracts;
using EncyclopediaGalactica.Backend.ApplicationDomain.Infrastructure.Database;
using EncyclopediaGalactica.BusinessLogic.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

#endregion

namespace EncyclopediaGalactica.BusinessLogic.Commands.Relation;

public class GetRelationsCommand(
    IRelationMapper mapper,
    DbContextOptions<DocumentDomainDbContext> dbContextOptions,
    ILogger<GetRelationsCommand> logger) : IGetRelationsCommand
{
    public async Task<List<RelationResult>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return await GetAllAsyncBusinessLogic(cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            string m = $"Error happened while executing {nameof(GetRelationsCommand)} command.";
            throw new GetRelationsCommandException(m, e);
        }
    }

    private async Task<List<RelationResult>> GetAllAsyncBusinessLogic(CancellationToken cancellationToken)
    {
        List<Entities.Relation> result = await GetAllAsyncDatabaseOperation(cancellationToken).ConfigureAwait(false);
        return mapper.MapRelationsToRelationResults(result);
    }

    private async Task<List<Entities.Relation>> GetAllAsyncDatabaseOperation(CancellationToken cancellationToken)
    {
        await using DocumentDomainDbContext ctx = new(dbContextOptions);
        return await ctx.Relations.ToListAsync(cancellationToken).ConfigureAwait(false);
    }
}