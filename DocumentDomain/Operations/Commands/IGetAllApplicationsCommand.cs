namespace EncyclopediaGalactica.DocumentDomain.Operations.Commands;

using EncyclopediaGalactica.BusinessLogic.Contracts;

public interface IGetAllApplicationsCommand
{
    Task<List<ApplicationResult>> GetAllAsync(CancellationToken cancellationToken = default);
}