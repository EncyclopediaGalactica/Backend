using EncyclopediaGalactica.Backend.ApplicationDomain.Contracts;

namespace EncyclopediaGalactica.Backend.ApplicationDomain.Operations.Commands;

public interface IGetAllApplicationsCommand
{
    Task<List<ApplicationContract>> GetAllAsync(CancellationToken cancellationToken = default);
}