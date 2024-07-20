namespace DocumentDomain.Infrastructure.Mappers;

using Contracts;
using Entity;

public interface IApplicationMapper
{
    List<ApplicationContract> ToApplicationResults(List<Application> applications);

    ApplicationContract ToApplicationResult(Application application);
}