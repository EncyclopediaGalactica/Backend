using EncyclopediaGalactica.Backend.ApplicationDomain.Contracts;
using EncyclopediaGalactica.Backend.ApplicationDomain.Operations.Commands;
using EncyclopediaGalactica.BusinessLogic.Sagas;
using EncyclopediaGalactica.BusinessLogic.Sagas.Interfaces;
using Microsoft.Extensions.Logging;

namespace EncyclopediaGalactica.Backend.ApplicationDomain.Operations.Sagas;

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