namespace DocumentDomain.Infrastructure.Mappers;

using Contracts;
using Entity;

public interface IApplicationInputMapper
{
    Application ToApplication(ApplicationInput applicationInput);
}