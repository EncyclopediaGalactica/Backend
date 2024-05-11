using EncyclopediaGalactica.BusinessLogic.Contracts;

namespace EncyclopediaGalactica.BusinessLogic.Commands.Application;

public interface IGetAllApplicationsCommand
{
    Task<List<ApplicationResult>> GetAllAsync(CancellationToken cancellationToken = default);
}