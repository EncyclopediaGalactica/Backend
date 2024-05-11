using EncyclopediaGalactica.BusinessLogic.Contracts;
using EncyclopediaGalactica.BusinessLogic.Sagas.Application;
using EncyclopediaGalactica.BusinessLogic.Sagas.Interfaces;
using HotChocolate.Resolvers;
using Microsoft.Extensions.Logging;

namespace EncyclopediaGalactica.Infrastructure.Graphql.Resolvers.QueryResolvers;

public class ApplicationQueryResolvers(ILogger<ApplicationQueryResolvers> logger)
{
    public async Task<List<ApplicationResult>> GetAllAsync(
        IResolverContext resolverContext,
        IHaveInputAndResultSaga<List<ApplicationResult>, GetAllApplicationsSagaContext> getApplicationsSaga,
        CancellationToken cancellationToken = default)
    {
        try
        {
            GetAllApplicationsSagaContext sagaContext = new GetAllApplicationsSagaContext();
            return await getApplicationsSaga.ExecuteAsync(sagaContext, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            logger.LogDebug("{OperationName} has failed. Message: {Message}; Stacktrace: {StackTrace}",
                nameof(GetAllAsync),
                e.Message,
                e.StackTrace);
            Console.WriteLine(e);
            throw;
        }
    }
}