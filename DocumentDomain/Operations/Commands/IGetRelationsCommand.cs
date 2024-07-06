#region

using DocumentDomain.Contracts;

#endregion

namespace EncyclopediaGalactica.BusinessLogic.Commands.Relation;

public interface IGetRelationsCommand
{
    Task<List<RelationResult>> GetAllAsync(CancellationToken cancellationToken = default);
}