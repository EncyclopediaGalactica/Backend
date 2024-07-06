#region

using Common.Validators;
using DocumentDomain.Contracts;
using EncyclopediaGalactica.Backend.ApplicationDomain.Infrastructure.Database;
using EncyclopediaGalactica.BusinessLogic.Mappers;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

#endregion

namespace EncyclopediaGalactica.BusinessLogic.Commands.Relation;

public class EditRelationCommand(
    IRelationMapper relationMapper,
    DbContextOptions<DocumentDomainDbContext> dbContextOptions,
    IValidator<RelationInput> validator,
    ILogger<EditRelationCommand> logger) : IEditRelationCommand
{
    public async Task EditAsync(RelationInput relationInput,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await EditBusinessLogicAsync(relationInput, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            string m = $"Error happened during {nameof(EditRelationCommand)} command execution.";
            throw new EditRelationCommandException(m, e);
        }
    }

    private async Task EditBusinessLogicAsync(RelationInput relationInput,
        CancellationToken cancellationToken)
    {
        await ValidateInput(relationInput, cancellationToken).ConfigureAwait(false);
        Entities.Relation inputRelation = relationMapper.MapRelationInputToRelation(relationInput);
        await EditDatabaseOperationAsync(inputRelation, cancellationToken).ConfigureAwait(false);
    }

    private async Task EditDatabaseOperationAsync(Entities.Relation inputRelation, CancellationToken cancellationToken)
    {
        await using DocumentDomainDbContext ctx = new(dbContextOptions);
        Entities.Relation toBeModified = await ctx.Relations
            .FirstAsync(p => p.Id == inputRelation.Id, cancellationToken)
            .ConfigureAwait(false);
        UpdateModifiedValues(toBeModified, inputRelation);
        ctx.Entry(toBeModified).State = EntityState.Modified;
        await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    private void UpdateModifiedValues(Entities.Relation toBeModified, Entities.Relation inputRelation)
    {
        toBeModified.LeftId = inputRelation.LeftId;
        toBeModified.RightId = inputRelation.RightId;
    }

    private async Task ValidateInput(RelationInput relationInput, CancellationToken cancellationToken = default)
    {
        await validator.ValidateAsync(relationInput, o =>
        {
            o.IncludeRuleSets(Operations.Update);
            o.ThrowOnFailures();
        }, cancellationToken).ConfigureAwait(false);
    }
}