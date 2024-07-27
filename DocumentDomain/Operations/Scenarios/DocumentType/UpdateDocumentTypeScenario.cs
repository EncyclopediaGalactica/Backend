namespace DocumentDomain.Operations.Scenarios.DocumentType;

using Commands;
using Common.Sagas;
using EncyclopediaGalactica.BusinessLogic.Contracts;

public class UpdateDocumentTypeScenario(
    IUpdateDocumentTypeCommand updateDocumentTypeCommand
) : IHaveInputAndResultSaga<DocumentTypeResult, UpdateDocumentTypeScenarioContext>
{
    public async Task<DocumentTypeResult> ExecuteAsync(
        UpdateDocumentTypeScenarioContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            return await updateDocumentTypeCommand.ExecuteAsync(context.Payload, cancellationToken)
                .ConfigureAwait(false);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}