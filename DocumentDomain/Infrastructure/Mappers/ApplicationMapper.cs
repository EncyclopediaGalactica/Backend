namespace DocumentDomain.Infrastructure.Mappers;

using EncyclopediaGalactica.BusinessLogic.Contracts;
using Entity;

public class ApplicationMapper : IApplicationMapper
{
    public List<ApplicationResult> ToApplicationResults(List<Application> applications)
    {
        var result = new List<ApplicationResult>();

        if (applications.Any()) result.AddRange(applications.Select(ToApplicationResult));

        return result;
    }

    public ApplicationResult ToApplicationResult(Application application)
    {
        return new ApplicationResult
        {
            Id = application.Id,
            Name = application.Name,
            Description = application.Description
        };
    }
}