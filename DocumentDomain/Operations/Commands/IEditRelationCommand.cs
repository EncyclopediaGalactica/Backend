#region

using DocumentDomain.Contracts;

#endregion

namespace EncyclopediaGalactica.BusinessLogic.Commands.Relation;

public interface IEditRelationCommand
{
    Task EditAsync(RelationInput relationInput, CancellationToken cancellationToken = default);
}