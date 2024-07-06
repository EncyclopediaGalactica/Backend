using EncyclopediaGalactica.Backend.ApplicationDomain.Contracts;

namespace EncyclopediaGalactica.Backend.ApplicationDomain.Operations.Commands;

public interface IAddApplicationCommand
{
    Task<ApplicationContract> AddAsync(ApplicationInput application, CancellationToken cancellationToken = default);
}