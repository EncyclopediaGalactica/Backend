#region

using Common.Sagas;
using DocumentDomain.Contracts;
using DocumentDomain.Entity;
using DocumentDomain.Infrastructure.Database;
using DocumentDomain.Infrastructure.Mappers;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

#endregion

namespace DocumentDomain.Operations.Commands;

public class AddNewRelationCommand(
    IValidator<RelationInput> validator,
    IRelationMapper mapper,
    DbContextOptions<DocumentDomainDbContext> dbContextOptions,
    ILogger<AddNewRelationCommand> logger) : IAddNewRelationCommand
{
    public async Task<long> AddNewRelationAsync(RelationInput payload, CancellationToken cancellationToken)
    {
        try
        {
            return await AddNewBusinessLogicAsync(payload, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            string m = $"Error happened during {nameof(AddNewRelationCommand)}.";
            throw new SagaException(m, e);
        }
    }

    private async Task<long> AddNewBusinessLogicAsync(RelationInput payload, CancellationToken cancellationToken)
    {
        await ValidateInput(payload, cancellationToken).ConfigureAwait(false);
        Relation relation = mapper.MapRelationInputToRelation(payload);
        return await AddNewDatabaseOperationAsync(relation, cancellationToken).ConfigureAwait(false);
    }

    private async Task<long> AddNewDatabaseOperationAsync(Relation relation,
        CancellationToken cancellationToken = default)
    {
        await using DocumentDomainDbContext ctx = new DocumentDomainDbContext(dbContextOptions);
        await ctx.Relations.AddAsync(relation, cancellationToken).ConfigureAwait(false);
        await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return relation.Id;
    }

    private async Task ValidateInput(RelationInput payload, CancellationToken cancellationToken = default)
    {
        await validator.ValidateAsync(payload, o =>
        {
            o.IncludeRuleSets(Common.Validators.Operations.Add);
            o.ThrowOnFailures();
        }, cancellationToken).ConfigureAwait(false);
    }
}