namespace DocumentDomain.Operations.Commands;

using Contracts;

public interface IGetAllApplicationsCommand
{
    Task<List<ApplicationContract>> GetAllAsync(CancellationToken cancellationToken = default);
}