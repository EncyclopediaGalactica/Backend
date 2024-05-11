using EncyclopediaGalactica.BusinessLogic.Contracts;
using EncyclopediaGalactica.BusinessLogic.Entities;

namespace EncyclopediaGalactica.BusinessLogic.Mappers;

public class ApplicationMapper : IApplicationMapper
{
    public List<ApplicationResult> MapApplicationsToApplicationResults(List<Application> applications)
    {
        List<ApplicationResult> result = new List<ApplicationResult>();

        if (applications.Any())
        {
            result.AddRange(applications.Select(MapApplicationToApplicationResult));
        }

        return result;
    }

    public ApplicationResult MapApplicationToApplicationResult(Application application)
    {
        return new ApplicationResult
        {
            Id = application.Id,
            Name = application.Name,
            Description = application.Description
        };
    }
}