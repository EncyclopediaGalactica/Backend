#region

#endregion

namespace DocumentDomain.Operations.Sagas;

using Commands;
using Common.Commands.Exceptions;
using Common.Sagas;
using Contracts;
using Microsoft.Extensions.Logging;

public class GetRelationByIdSaga(
    IGetRelationByIdCommand getRelationByIdCommand,
    ILogger<GetRelationByIdSaga> logger) : IHaveInputAndResultSaga<RelationResult, GetRelationByIdSagaContext>
{
    public async Task<RelationResult> ExecuteAsync(GetRelationByIdSagaContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            return await SagaBusinessLogicAsync(context.Payload, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            string m = $"Error happened while executing {nameof(GetRelationByIdSaga)} saga.";
            throw new SagaException(m, e);
        }
    }

    private async Task<RelationResult> SagaBusinessLogicAsync(long payload, CancellationToken cancellationToken)
    {
        ValidateInput(payload);
        return await getRelationByIdCommand.GetByIdAsync(payload, cancellationToken).ConfigureAwait(false);
    }

    private void ValidateInput(long payload)
    {
        long notAllowedValue = 0;
        if (payload == notAllowedValue)
        {
            string m = $"{nameof(payload)} cannot be {notAllowedValue}";
            throw new InvalidArgumentCommandException(m);
        }
    }
}