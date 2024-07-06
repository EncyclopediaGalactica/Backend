using EncyclopediaGalactica.Backend.ApplicationDomain.Contracts;
using EncyclopediaGalactica.Backend.ApplicationDomain.Entities;

namespace EncyclopediaGalactica.Backend.ApplicationDomain.Infrastructure.Mappers;

public interface IApplicationInputMapper
{
    Application ToApplication(ApplicationInput applicationInput);
}