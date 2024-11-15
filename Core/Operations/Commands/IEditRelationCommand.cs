namespace EncyclopediaGalactica.Core.Operations.Commands;

using BusinessLogic.Contracts;

public interface IEditRelationCommand
{
    Task EditAsync(RelationInput relationInput, CancellationToken cancellationToken = default);
}