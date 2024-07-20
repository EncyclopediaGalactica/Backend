#region

#endregion

namespace DocumentDomain.Operations.Commands;

using Contracts;
using Entity;
using Infrastructure.Database;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class AddApplicationCommand(
    IApplicationMapper applicationMapper,
    IApplicationInputMapper applicationInputMapper,
    ILogger<AddApplicationCommand> logger,
    DbContextOptions<DocumentDomainDbContext> dbContextOptions) : IAddApplicationCommand
{
    public async Task<ApplicationContract> AddAsync(
        ApplicationInput applicationInput,
        CancellationToken cancellationToken = default)
    {
        try
        {
            return await ExecuteCommandAsync(applicationInput, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            logger.LogError(
                "Error happened while executing {CommandName} command. " +
                "Further details: {ExceptionMessage}",
                nameof(AddApplicationCommand),
                e.Message);
            throw;
        }
    }

    private async Task<ApplicationContract> ExecuteCommandAsync(
        ApplicationInput applicationInput,
        CancellationToken cancellationToken)
    {
        Application application = applicationInputMapper.ToApplication(applicationInput);
        Application recorded = await RecordEntityAsync(application, cancellationToken).ConfigureAwait(false);
        return applicationMapper.ToApplicationResult(recorded);
    }

    private async Task<Application> RecordEntityAsync(
        Application application,
        CancellationToken cancellationToken)
    {
        await using DocumentDomainDbContext ctx = new DocumentDomainDbContext(dbContextOptions);
        await ctx.Applications.AddAsync(application, cancellationToken).ConfigureAwait(false);
        return application;
    }
}