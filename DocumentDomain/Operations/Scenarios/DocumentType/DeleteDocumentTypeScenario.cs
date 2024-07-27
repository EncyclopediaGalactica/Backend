namespace DocumentDomain.Operations.Scenarios.DocumentType;

using Commands.DocumentType;
using Common.Sagas;

public class DeleteDocumentTypeScenario(
    IDeleteDocumentTypeCommand deleteDocumentTypeCommand
) : IHaveInputSaga<DeleteDocumentTypeScenarioContext>
{
    public async Task ExecuteAsync(DeleteDocumentTypeScenarioContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await deleteDocumentTypeCommand.ExecuteAsync(
                context.Payload,
                cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}