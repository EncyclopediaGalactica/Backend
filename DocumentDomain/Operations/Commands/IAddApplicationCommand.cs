namespace DocumentDomain.Operations.Commands;

using EncyclopediaGalactica.BusinessLogic.Contracts;

/// Add Application Command Interface
public interface IAddApplicationCommand
{
    Task<ApplicationResult> AddAsync(ApplicationInput application, CancellationToken cancellationToken = default);
}