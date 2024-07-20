#region

#endregion

namespace DocumentDomain.Operations.Commands;

using Contracts;

public interface IGetRelationsCommand
{
    Task<List<RelationResult>> GetAllAsync(CancellationToken cancellationToken = default);
}