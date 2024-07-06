#region

using DocumentDomain.Contracts;

#endregion

namespace DocumentDomain.Operations.Commands;

public interface IGetRelationByIdCommand
{
    Task<RelationResult> GetByIdAsync(long relationId, CancellationToken cancellationToken);
}