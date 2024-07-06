using EncyclopediaGalactica.Backend.ApplicationDomain.Contracts;
using EncyclopediaGalactica.Backend.ApplicationDomain.Entities;

namespace EncyclopediaGalactica.Backend.ApplicationDomain.Infrastructure.Mappers;

public interface IApplicationMapper
{
    List<ApplicationContract> ToApplicationResults(List<Application> applications);

    ApplicationContract ToApplicationResult(Application application);
}