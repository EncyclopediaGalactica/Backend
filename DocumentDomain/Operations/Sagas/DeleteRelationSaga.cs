#region

using Common.Commands.Exceptions;
using Common.Sagas;
using DocumentDomain.Operations.Commands;
using Microsoft.Extensions.Logging;

#endregion

namespace DocumentDomain.Operations.Sagas;

public class DeleteRelationSaga(
    IDeleteRelationCommand deleteRelationCommand,
    ILogger<DeleteRelationSaga> logger) : IHaveInputSaga<DeleteRelationSagaContext>
{
    public async Task ExecuteAsync(DeleteRelationSagaContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            await ExecuteBusinessLogicAsync(context.Payload, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            string m = $"Error happened during execution of {nameof(DeleteRelationSaga)} saga.";
            throw new SagaException(m, e);
        }
    }

    private async Task ExecuteBusinessLogicAsync(long contextPayload, CancellationToken cancellationToken)
    {
        ValidateInput(contextPayload);
        await deleteRelationCommand.DeleteAsync(contextPayload, cancellationToken).ConfigureAwait(false);
    }

    private void ValidateInput(long relationId)
    {
        long notAllowedValue = 0;
        if (relationId == notAllowedValue)
        {
            string m = $"{nameof(relationId)} cannot be {notAllowedValue}";
            throw new InvalidArgumentCommandException(m);
        }
    }
}