#region

using Common.Sagas;
using DocumentDomain.Contracts;
using DocumentDomain.Operations.Commands;
using Microsoft.Extensions.Logging;

#endregion

namespace DocumentDomain.Operations.Sagas;

public class GetDocumentByIdSaga(
    IGetDocumentByIdCommand getDocumentByIdCommand,
    ILogger<GetDocumentsSaga> logger) : IHaveInputAndResultSaga<DocumentResult, GetDocumentByIdContext>
{
    public async Task<DocumentResult> ExecuteAsync(GetDocumentByIdContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            return await getDocumentByIdCommand.GetByIdAsync(context.Payload, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            string m = $"Error happened during execution of {nameof(GetDocumentByIdSaga)}";
            throw new SagaException(m, e);
        }
    }
}