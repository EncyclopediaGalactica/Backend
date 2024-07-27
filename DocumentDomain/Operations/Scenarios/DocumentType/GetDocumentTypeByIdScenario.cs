namespace DocumentDomain.Operations.Scenarios.DocumentType;

using Commands;
using Common.Sagas;
using EncyclopediaGalactica.BusinessLogic.Contracts;

public class GetDocumentTypeByIdScenario(
    IGetDocumentTypeByIdCommand getDocumentTypeByIdCommand
) : IHaveInputAndResultSaga<DocumentTypeResult, GetDocumentTypeByIdScenarioContext>
{
    public async Task<DocumentTypeResult> ExecuteAsync(
        GetDocumentTypeByIdScenarioContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            return await getDocumentTypeByIdCommand.ExecuteAsync(context.Payload, cancellationToken)
                .ConfigureAwait(false);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}