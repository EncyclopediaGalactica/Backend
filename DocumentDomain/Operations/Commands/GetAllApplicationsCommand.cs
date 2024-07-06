#region

using EncyclopediaGalactica.Backend.ApplicationDomain.Contracts;
using EncyclopediaGalactica.Backend.ApplicationDomain.Entities;
using EncyclopediaGalactica.Backend.ApplicationDomain.Infrastructure.Database;
using EncyclopediaGalactica.Backend.ApplicationDomain.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

#endregion

namespace EncyclopediaGalactica.Backend.ApplicationDomain.Operations.Commands;

public class GetAllApplicationsCommand(
    IApplicationMapper applicationMapper,
    DbContextOptions<DocumentDomainDbContext> dbContextOptions) : IGetAllApplicationsCommand
{
    public async Task<List<ApplicationContract>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return await ExecuteBusinessLogicAsync().ConfigureAwait(false);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task<List<ApplicationContract>> ExecuteBusinessLogicAsync()
    {
        var applications = await GetApplicationsFromDatabase().ConfigureAwait(false);
        return applicationMapper.ToApplicationResults(applications);
    }

    private async Task<List<Application>> GetApplicationsFromDatabase()
    {
        await using var ctx = new DocumentDomainDbContext(dbContextOptions);
        return await ctx.Applications.ToListAsync().ConfigureAwait(false);
    }
}