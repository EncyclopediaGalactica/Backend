namespace EncyclopediaGalactica.Core.Operations.Scenarios;

using BusinessLogic.Contracts;
using Commands;
using Common.Scenario;
using LanguageExt;

public class GetRelationsSaga(
    IGetRelationsCommand getRelationsCommand) : IHaveInputAndResultSaga<List<RelationResult>, GetRelationSagaContext>
{
    public async Task<Option<List<RelationResult>>> ExecuteAsync(GetRelationSagaContext context,
                                                                 CancellationToken      cancellationToken = default)
    {
        try
        {
            return await getRelationsCommand.GetAllAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            string m = $"Error happened while executing {nameof(GetRelationsSaga)} saga.";
            throw new SagaException(m, e);
        }
    }
}