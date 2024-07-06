using Common.Sagas;
using DocumentDomain.Operations.Commands;
using Microsoft.Extensions.Logging;

namespace DocumentDomain.Operations.Sagas;

public class DeleteDocumentSaga(
    IDeleteDocumentCommand deleteDocumentCommand,
    IDeleteStructureNodesCommand deleteStructureNodesCommand,
    ILogger<DeleteDocumentSaga> logger) : IHaveInputSaga<DeleteDocumentSagaContext>
{
    public async Task ExecuteAsync(DeleteDocumentSagaContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await deleteDocumentCommand.DeleteAsync(context.Payload, cancellationToken)
                .ConfigureAwait(false);
            await deleteStructureNodesCommand.DeleteAsync(context.Payload, cancellationToken)
                .ConfigureAwait(false);
        }
        catch (Exception e)
        {
            string m = $"Error happened during {nameof(DeleteDocumentSaga)}.";
            throw new SagaException(m, e);
        }
    }
}