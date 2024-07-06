using DocumentDomain.Contracts;
using DocumentDomain.Entity;

namespace DocumentDomain.Infrastructure.Mappers;

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