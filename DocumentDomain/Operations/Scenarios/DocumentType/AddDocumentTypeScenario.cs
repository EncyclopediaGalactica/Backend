namespace DocumentDomain.Operations.Scenarios.DocumentType;

using Commands;
using Common.Sagas;
using EncyclopediaGalactica.BusinessLogic.Contracts;

public class AddDocumentTypeScenario(
    IAddDocumentTypeCommand addDocumentTypeCommand
) : IHaveInputAndResultSaga<DocumentTypeResult, AddDocumentTypeScenarioContext>
{
    public async Task<DocumentTypeResult> ExecuteAsync(
        AddDocumentTypeScenarioContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            return await ExecuteOperationAsync(context.Payload, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task<DocumentTypeResult> ExecuteOperationAsync(DocumentTypeInput? payload,
        CancellationToken cancellationToken)
    {
        return await addDocumentTypeCommand.ExecuteCommandAsync(payload, cancellationToken).ConfigureAwait(false);
    }
}