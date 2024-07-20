namespace DocumentDomain.Infrastructure.Mappers;

using Contracts;
using Entity;

public class ApplicationInputMapper : IApplicationInputMapper
{
    public Application ToApplication(ApplicationInput applicationInput)
    {
        return new Application
        {
            Id = applicationInput.Id,
            Name = applicationInput.Name,
            Description = applicationInput.Description
        };
    }
}