#region

#endregion

namespace DocumentDomain.Operations.Commands;

using Contracts;

public interface IAddNewRelationCommand
{
    Task<long> AddNewRelationAsync(RelationInput payload, CancellationToken cancellationToken);
}