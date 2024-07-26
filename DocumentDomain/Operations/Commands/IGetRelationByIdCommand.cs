namespace DocumentDomain.Operations.Commands;

using EncyclopediaGalactica.BusinessLogic.Contracts;

public interface IGetRelationByIdCommand
{
    Task<RelationResult> GetByIdAsync(long relationId, CancellationToken cancellationToken);
}