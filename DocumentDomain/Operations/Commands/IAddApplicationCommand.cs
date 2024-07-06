using DocumentDomain.Contracts;

namespace DocumentDomain.Operations.Commands;

public interface IAddApplicationCommand
{
    Task<ApplicationContract> AddAsync(ApplicationInput application, CancellationToken cancellationToken = default);
}