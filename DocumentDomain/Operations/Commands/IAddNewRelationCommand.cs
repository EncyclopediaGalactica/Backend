#region

using DocumentDomain.Contracts;

#endregion

namespace EncyclopediaGalactica.BusinessLogic.Commands.Relation;

public interface IAddNewRelationCommand
{
    Task<long> AddNewRelationAsync(RelationInput payload, CancellationToken cancellationToken);
}