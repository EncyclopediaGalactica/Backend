using EncyclopediaGalactica.BusinessLogic.Commands.Application;
using EncyclopediaGalactica.BusinessLogic.Contracts;
using EncyclopediaGalactica.BusinessLogic.Sagas.Interfaces;
using Microsoft.Extensions.Logging;

namespace EncyclopediaGalactica.BusinessLogic.Sagas.Application;

public class GetAllApplicationsSaga(
    IGetAllApplicationsCommand getAllApplicationsCommand,
    ILogger<GetAllApplicationsSaga> logger) : IHaveInputAndResultSaga<List<ApplicationResult>, GetAllApplicationsSagaContext>
{
    public async Task<List<ApplicationResult>> ExecuteAsync(
        GetAllApplicationsSagaContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            return await getAllApplicationsCommand.GetAllAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            string m = $"Error happened while executing {nameof(GetAllApplicationsSaga)}.";
            throw new SagaException(m, e);
        }
    }
}