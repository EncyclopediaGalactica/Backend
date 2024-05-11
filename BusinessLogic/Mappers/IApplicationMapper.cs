using EncyclopediaGalactica.BusinessLogic.Contracts;
using EncyclopediaGalactica.BusinessLogic.Entities;

namespace EncyclopediaGalactica.BusinessLogic.Mappers;

public interface IApplicationMapper
{
    List<ApplicationResult> MapApplicationsToApplicationResults(List<Application> applications);

    ApplicationResult MapApplicationToApplicationResult(Application application);
}