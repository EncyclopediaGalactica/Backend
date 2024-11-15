namespace EncyclopediaGalactica.Core.Operations.Commands;

using BusinessLogic.Contracts;

public interface IGetRelationsCommand
{
    Task<List<RelationResult>> GetAllAsync(CancellationToken cancellationToken = default);
}