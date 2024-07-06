using DocumentDomain.Contracts;

namespace DocumentDomain.Operations.Commands;

public interface IGetAllApplicationsCommand
{
    Task<List<ApplicationContract>> GetAllAsync(CancellationToken cancellationToken = default);
}