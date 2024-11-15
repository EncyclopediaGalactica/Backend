namespace EncyclopediaGalactica.Core.Operations.Commands;

using Application;
using Infrastructure.Database;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using ApplicationResult = BusinessLogic.Contracts.ApplicationResult;

public class GetAllApplicationsCommand(
    IApplicationMapper                        applicationMapper,
    DbContextOptions<DocumentDomainDbContext> dbContextOptions) : IGetAllApplicationsCommand
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
        List<Application>? applications = await GetApplicationsFromDatabase().ConfigureAwait(false);
        return applicationMapper.ToApplicationResults(applications);
    }

    private async Task<List<Application>> GetApplicationsFromDatabase()
    {
        await using DocumentDomainDbContext ctx = new(dbContextOptions);
        return await ctx.Applications.ToListAsync().ConfigureAwait(false);
    }
}