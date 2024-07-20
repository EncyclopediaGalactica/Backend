#region

#endregion

namespace DocumentDomain.Operations.Commands;

using Contracts;

public interface IEditRelationCommand
{
    Task EditAsync(RelationInput relationInput, CancellationToken cancellationToken = default);
}