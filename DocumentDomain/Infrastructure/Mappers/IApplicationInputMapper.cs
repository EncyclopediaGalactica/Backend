using DocumentDomain.Contracts;
using DocumentDomain.Entity;

namespace DocumentDomain.Infrastructure.Mappers;

public interface IApplicationInputMapper
{
    Application ToApplication(ApplicationInput applicationInput);
}