namespace DocumentDomain.Operations.Commands;

using Contracts;

public interface IAddApplicationCommand
{
    Task<ApplicationContract> AddAsync(ApplicationInput application, CancellationToken cancellationToken = default);
}