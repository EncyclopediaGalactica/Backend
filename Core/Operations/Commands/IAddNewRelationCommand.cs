namespace EncyclopediaGalactica.Core.Operations.Commands;

using BusinessLogic.Contracts;

public interface IAddNewRelationCommand
{
    Task<long> AddNewRelationAsync(RelationInput payload, CancellationToken cancellationToken);
}