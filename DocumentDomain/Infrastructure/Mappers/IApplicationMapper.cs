namespace DocumentDomain.Infrastructure.Mappers;

using EncyclopediaGalactica.BusinessLogic.Contracts;
using Entity;

public interface IApplicationMapper
{
    List<ApplicationResult> ToApplicationResults(List<Application> applications);

    ApplicationResult ToApplicationResult(Application application);
}