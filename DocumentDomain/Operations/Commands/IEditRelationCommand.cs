#region

using DocumentDomain.Contracts;

#endregion

namespace DocumentDomain.Operations.Commands;

public interface IEditRelationCommand
{
    Task EditAsync(RelationInput relationInput, CancellationToken cancellationToken = default);
}