#region

using Common.Commands.Exceptions;
using Common.Sagas;
using DocumentDomain.Contracts;
using DocumentDomain.Entity;
using DocumentDomain.Infrastructure.Database;
using DocumentDomain.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

#endregion

namespace DocumentDomain.Operations.Commands;

public class GetRelationByIdCommand(
    IRelationMapper mapper,
    DbContextOptions<DocumentDomainDbContext> dbContextOptions,
    ILogger<GetRelationByIdCommand> logger) : IGetRelationByIdCommand
{
    public async Task<RelationResult> GetByIdAsync(long relationId, CancellationToken cancellationToken)
    {
        try
        {
            return await GetIdByBusinessLogicAsync(relationId, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            string m = $"Error happened during {nameof(GetRelationByIdCommand)}.";
            throw new SagaException(m, e);
        }
    }

    private async Task<RelationResult> GetIdByBusinessLogicAsync(long relationId, CancellationToken cancellationToken)
    {
        ValidateInput(relationId);
        Relation result =
            await GetByIdAsyncDatabaseOperation(relationId, cancellationToken).ConfigureAwait(false);
        return mapper.MapRelationToRelationResult(result);
    }

    private async Task<Relation> GetByIdAsyncDatabaseOperation(long relationId,
        CancellationToken cancellationToken)
    {
        await using DocumentDomainDbContext ctx = new(dbContextOptions);
        return await ctx.Relations.FirstAsync(p => p.Id == relationId, cancellationToken).ConfigureAwait(false);
    }

    private void ValidateInput(long relationId)
    {
        long notAllowedValue = 0;
        if (relationId == notAllowedValue)
        {
            string m = $"{nameof(relationId)} cannot be {notAllowedValue}";
            throw new InvalidArgumentCommandException(m);
        }
    }
}