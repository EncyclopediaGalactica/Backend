using DocumentDomain.Contracts;
using DocumentDomain.Entity;

namespace DocumentDomain.Infrastructure.Mappers;

public interface IApplicationMapper
{
    List<ApplicationContract> ToApplicationResults(List<Application> applications);

    ApplicationContract ToApplicationResult(Application application);
}