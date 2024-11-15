namespace EncyclopediaGalactica.Core.Operations.Commands;

using BusinessLogic.Contracts;

public interface IGetAllApplicationsCommand
{
    Task<List<ApplicationResult>> GetAllAsync(CancellationToken cancellationToken = default);
}