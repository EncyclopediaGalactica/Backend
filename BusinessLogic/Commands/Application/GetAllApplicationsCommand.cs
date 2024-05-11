using EncyclopediaGalactica.BusinessLogic.Contracts;
using EncyclopediaGalactica.BusinessLogic.Database;
using EncyclopediaGalactica.BusinessLogic.Mappers;
using Microsoft.EntityFrameworkCore;

namespace EncyclopediaGalactica.BusinessLogic.Commands.Application;

public class GetAllApplicationsCommand(
    IApplicationMapper applicationMapper,
    DbContextOptions<DocumentDbContext> dbContextOptions) : IGetAllApplicationsCommand
{
    public async Task<List<ApplicationResult>> GetAllAsync(CancellationToken cancellationToken = default)
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

    private async Task<List<ApplicationResult>> ExecuteBusinessLogicAsync()
    {
        List<Entities.Application> applications = await GetApplicationsFromDatabase().ConfigureAwait(false);
        return applicationMapper.MapApplicationsToApplicationResults(applications);
    }

    private async Task<List<Entities.Application>> GetApplicationsFromDatabase()
    {
        await using DocumentDbContext ctx = new DocumentDbContext(dbContextOptions);
        return await ctx.Applications.ToListAsync().ConfigureAwait(false);
    }
}