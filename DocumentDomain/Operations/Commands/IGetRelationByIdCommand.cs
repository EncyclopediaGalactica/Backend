#region

#endregion

namespace DocumentDomain.Operations.Commands;

using Contracts;

public interface IGetRelationByIdCommand
{
    Task<RelationResult> GetByIdAsync(long relationId, CancellationToken cancellationToken);
}