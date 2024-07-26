namespace DocumentDomain.Operations.Commands;

using EncyclopediaGalactica.BusinessLogic.Contracts;

public interface IAddApplicationCommand
{
    Task<ApplicationResult> AddAsync(ApplicationInput application, CancellationToken cancellationToken = default);
}