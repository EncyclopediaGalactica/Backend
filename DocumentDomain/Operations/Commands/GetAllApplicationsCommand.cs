#region

#endregion

namespace DocumentDomain.Operations.Commands;

using Contracts;
using Entity;
using Infrastructure.Database;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

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