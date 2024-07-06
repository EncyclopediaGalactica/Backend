#region

using DocumentDomain.Contracts;

#endregion

namespace EncyclopediaGalactica.BusinessLogic.Commands.Relation;

public interface IGetRelationByIdCommand
{
    Task<RelationResult> GetByIdAsync(long relationId, CancellationToken cancellationToken);
}