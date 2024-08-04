namespace DocumentDomain.Operations.Commands;

using EncyclopediaGalactica.BusinessLogic.Contracts;

public interface IEditRelationCommand
{
    Task EditAsync(RelationInput relationInput, CancellationToken cancellationToken = default);
}