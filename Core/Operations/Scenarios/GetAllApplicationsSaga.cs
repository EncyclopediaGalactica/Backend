namespace EncyclopediaGalactica.Core.Operations.Scenarios;

using BusinessLogic.Contracts;

using Commands;

using Common.Scenario;

using LanguageExt;

using Microsoft.Extensions.Logging;

public class GetAllApplicationsSaga(
    IGetAllApplicationsCommand      getAllApplicationsCommand,
    ILogger<GetAllApplicationsSaga> logger)
    : IHaveInputAndResultSaga<List<ApplicationResult>, GetAllApplicationsSagaContext>
{
    public async Task<Option<List<ApplicationResult>>> ExecuteAsync(
        GetAllApplicationsSagaContext context,
        CancellationToken             cancellationToken = default)
    {
        try
        {
            return await getAllApplicationsCommand.GetAllAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            string? m = $"Error happened while executing {nameof(GetAllApplicationsSaga)}.";
            throw new SagaException(m, e);
        }
    }
}