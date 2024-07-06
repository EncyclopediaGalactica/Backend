#region

using DocumentDomain.Contracts;

#endregion

namespace DocumentDomain.Operations.Commands;

public interface IGetRelationsCommand
{
    Task<List<RelationResult>> GetAllAsync(CancellationToken cancellationToken = default);
}