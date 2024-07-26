namespace DocumentDomain.Operations.Sagas;

using Commands;
using Common.Sagas;
using EncyclopediaGalactica.BusinessLogic.Contracts;

public class GetRelationsSaga(
    IGetRelationsCommand getRelationsCommand) : IHaveInputAndResultSaga<List<RelationResult>, GetRelationSagaContext>
{
    public async Task<List<RelationResult>> ExecuteAsync(GetRelationSagaContext context,
        CancellationToken cancellationToken = default)
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