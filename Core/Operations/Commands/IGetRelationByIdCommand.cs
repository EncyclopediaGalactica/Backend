namespace EncyclopediaGalactica.Core.Operations.Commands;

using BusinessLogic.Contracts;

public interface IGetRelationByIdCommand
{
    Task<RelationResult> GetByIdAsync(long relationId, CancellationToken cancellationToken);
}