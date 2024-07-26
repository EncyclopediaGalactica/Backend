namespace DocumentDomain.Operations.Commands;

using EncyclopediaGalactica.BusinessLogic.Contracts;

public interface IAddNewRelationCommand
{
    Task<long> AddNewRelationAsync(RelationInput payload, CancellationToken cancellationToken);
}