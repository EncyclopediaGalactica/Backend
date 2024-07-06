using Common.Sagas;
using DocumentDomain.Contracts;
using DocumentDomain.Operations.Commands;
using Microsoft.Extensions.Logging;

namespace DocumentDomain.Operations.Sagas;

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