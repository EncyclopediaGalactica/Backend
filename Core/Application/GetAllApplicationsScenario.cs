namespace EncyclopediaGalactica.Core.Application;

using Common;

using LanguageExt;

using Microsoft.EntityFrameworkCore;

public class GetAllApplicationsScenario(
    DbContextOptions<DocumentDomainDbContext> dbContextOptions
)
{
    public Either<ErrorResult, List<ApplicationResult>> Execute(
        GetAllApplicationsScenarioContext context
    )
    {
        Either<ErrorResult, List<ApplicationResult>> result =
            from resultFromStorage in GetEntitiesFromStorage(context)
            from mappedResult in MapResultsToContracts(resultFromStorage)
            select mappedResult;
        return result;
    }

    private static Either<ErrorResult, List<ApplicationResult>> MapResultsToContracts(
        List<Application> resultFromStorage) =>
        Either<ErrorResult, List<ApplicationResult>>.Right(resultFromStorage.ToApplicationResults());

    private Either<ErrorResult, List<Application>> GetEntitiesFromStorage(
        GetAllApplicationsScenarioContext context
    )
    {
        using DocumentDomainDbContext ctx = new(dbContextOptions);
        try
        {
            List<Application> result = ctx.Applications.ToList();
            return Either<ErrorResult, List<Application>>.Right(result);
        }
        catch (Exception e)
        {
            return Either<ErrorResult, List<Application>>.Left(
                new ErrorResult(context.CorrelationId, e.Message)
            );
        }
    }
}

public record GetAllApplicationsScenarioContext(Guid CorrelationId);
