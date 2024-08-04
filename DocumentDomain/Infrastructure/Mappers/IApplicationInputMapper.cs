namespace DocumentDomain.Infrastructure.Mappers;

using EncyclopediaGalactica.BusinessLogic.Contracts;
using Entity;

public interface IApplicationInputMapper
{
    Application ToApplication(ApplicationInput applicationInput);
}