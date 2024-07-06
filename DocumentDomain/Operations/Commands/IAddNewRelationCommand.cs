#region

using DocumentDomain.Contracts;

#endregion

namespace DocumentDomain.Operations.Commands;

public interface IAddNewRelationCommand
{
    Task<long> AddNewRelationAsync(RelationInput payload, CancellationToken cancellationToken);
}