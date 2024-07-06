#region

using Common.Sagas;
using DocumentDomain.Contracts;
using DocumentDomain.Operations.Commands;
using Microsoft.Extensions.Logging;

#endregion

namespace DocumentDomain.Operations.Sagas;

public class NewRelationSaga(
    IAddNewRelationCommand addNewRelationCommand,
    IGetRelationByIdCommand getRelationByIdCommand,
    ILogger<NewRelationSaga> logger) : IHaveInputAndResultSaga<RelationResult, NewRelationSagaContext>
{
    public async Task<RelationResult> ExecuteAsync(NewRelationSagaContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            long relationId = await addNewRelationCommand.AddNewRelationAsync(context.Payload, cancellationToken)
                .ConfigureAwait(false);
            return await getRelationByIdCommand.GetByIdAsync(relationId, cancellationToken)
                .ConfigureAwait(false);
        }
        catch (Exception e)
        {
            string m = $"Error happened while executing {nameof(NewRelationSaga)}.";
            throw new SagaException(m, e);
        }
    }
}