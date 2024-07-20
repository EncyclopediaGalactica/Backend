#region

#endregion

namespace DocumentDomain.Operations.Sagas;

using Commands;
using Common.Sagas;
using Contracts;
using Microsoft.Extensions.Logging;

/// <inheritdoc />
public class AddDocumentSaga(
    IAddDocumentCommand addDocumentCommand,
    IAddStructureNodeTreeCommand addStructureNodeTreeCommand,
    IGetDocumentByIdCommand getDocumentByIdCommand,
    ILogger<AddDocumentSaga> logger) : IHaveInputAndResultSaga<DocumentResult, AddDocumentSagaContext>
{
    /// <summary>
    ///     Executes the saga
    /// </summary>
    /// <param name="context">Context including the <see cref="TPayloadType" />.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken" />.</param>
    /// <returns>
    ///     <see cref="TReturnType" />
    /// </returns>
    public async Task<DocumentResult> ExecuteAsync(AddDocumentSagaContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            long documentId = await addDocumentCommand.AddAsync(context.Payload, cancellationToken)
                .ConfigureAwait(false);

            DocumentResult result = await getDocumentByIdCommand.GetByIdAsync(documentId, cancellationToken)
                .ConfigureAwait(false);
            return result;
        }
        catch (Exception e)
        {
            string m = $"Error happened while executing {nameof(AddDocumentSaga)}.";
            throw new SagaException(m, e);
        }
    }
}