namespace EncyclopediaGalactica.Core.Operations.Scenarios.Relation;

using BusinessLogic.Contracts;

using Infrastructure.Database;
using Infrastructure.Mappers;

using LanguageExt;

using Microsoft.EntityFrameworkCore;

using Relation = Entity.Relation;

public class GetRelationByIdScenario(
    RelationMapper                            mapper,
    DbContextOptions<DocumentDomainDbContext> dbContextOptions)
{
    private Guid _correlationId;

    public async Task<Either<ErrorResult, RelationResult>> ExecuteAsync(
        GetRelationByIdScenarioContext context,
        CancellationToken              cancellationToken = default)
    {
        _correlationId = context.CorrelationId;
        Either<ErrorResult, RelationResult> result =
            from entity in FetchFromDatabase(context, cancellationToken)
            from mappedEntity in MapToRelationResult(entity)
            select mappedEntity;
        return result;
    }

    private Either<ErrorResult, RelationResult> MapToRelationResult(Relation entity) =>
        mapper.MapRelationToRelationResult(entity);

    private Either<ErrorResult, Relation> FetchFromDatabase(
        GetRelationByIdScenarioContext context,
        CancellationToken              cancellationToken)
    {
        using DocumentDomainDbContext ctx = new(dbContextOptions);
        try
        {
            Relation entity = ctx.Relations.First(i => i.Id == context.Payload.Id);
            return entity;
        }
        catch (Exception e)
        {
            return new ErrorResult(_correlationId, e.Message);
        }
    }
}

public record GetRelationByIdScenarioContext(Guid CorrelationId, RelationInput Payload);