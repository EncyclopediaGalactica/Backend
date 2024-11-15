namespace EncyclopediaGalactica.Core.Operations.Commands;

public interface IDeleteRelationCommand
{
    Task DeleteAsync(long relationId, CancellationToken cancellationToken);
}