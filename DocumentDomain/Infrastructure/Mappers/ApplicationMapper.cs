namespace DocumentDomain.Infrastructure.Mappers;

using Contracts;
using Entity;

public class ApplicationMapper : IApplicationMapper
{
    public List<ApplicationContract> ToApplicationResults(List<Application> applications)
    {
        var result = new List<ApplicationContract>();

        if (applications.Any()) result.AddRange(applications.Select(ToApplicationResult));

        return result;
    }

    public ApplicationContract ToApplicationResult(Application application)
    {
        return new ApplicationContract
        {
            Id = application.Id,
            Name = application.Name,
            Description = application.Description
        };
    }
}