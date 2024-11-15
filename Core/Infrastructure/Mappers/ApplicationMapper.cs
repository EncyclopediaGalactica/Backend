namespace EncyclopediaGalactica.Core.Infrastructure.Mappers;

using Application;

using ApplicationInput = BusinessLogic.Contracts.ApplicationInput;
using ApplicationResult = BusinessLogic.Contracts.ApplicationResult;

public class ApplicationMapper : IApplicationMapper
{
    public List<ApplicationResult> ToApplicationResults(List<Application> applications)
    {
        List<ApplicationResult> result = new();

        if (applications.Any())
        {
            result.AddRange(applications.Select(ToApplicationResult));
        }

        return result;
    }

    public ApplicationResult ToApplicationResult(Application application) =>
        new()
        {
            Id          = application.Id,
            Name        = application.Name,
            Description = application.Description,
        };

    public Application FromApplicationInput(ApplicationInput applicationInput) =>
        new()
        {
            Id          = applicationInput.Id,
            Name        = applicationInput.Name,
            Description = applicationInput.Description,
        };
}

public interface IApplicationMapper
{
    List<ApplicationResult> ToApplicationResults(List<Application> applications);

    ApplicationResult ToApplicationResult(Application application);
    Application FromApplicationInput(ApplicationInput applicationInput);
}