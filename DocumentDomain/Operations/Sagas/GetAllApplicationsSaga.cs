namespace DocumentDomain.Operations.Sagas;

using Commands;
using Common.Sagas;
using Contracts;
using Microsoft.Extensions.Logging;

public class GetAllApplicationsSaga(
    IGetAllApplicationsCommand getAllApplicationsCommand,
    ILogger<GetAllApplicationsSaga> logger)
    : IHaveInputAndResultSaga<List<ApplicationContract>, GetAllApplicationsSagaContext>
{
    public async Task<List<ApplicationContract>> ExecuteAsync(
        GetAllApplicationsSagaContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            return await getAllApplicationsCommand.GetAllAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            var m = $"Error happened while executing {nameof(GetAllApplicationsSaga)}.";
            throw new SagaException(m, e);
        }
    }
}