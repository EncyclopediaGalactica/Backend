using EncyclopediaGalactica.Backend.ApplicationDomain.Contracts;
using EncyclopediaGalactica.Backend.ApplicationDomain.Entities;

namespace EncyclopediaGalactica.Backend.ApplicationDomain.Infrastructure.Mappers;

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