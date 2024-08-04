namespace DocumentDomain.Operations.Scenarios.DocumentType;

using Commands;
using Common.Sagas;
using EncyclopediaGalactica.BusinessLogic.Contracts;
using LanguageExt;

/// <summary>
///     Update the designated <see cref="DocumentType" /> entity scenario.
/// </summary>
/// <remarks>
///     The scenario provides a single method Api to execute the update operation safely.
/// </remarks>
/// <param name="updateDocumentTypeCommand"><see cref="IUpdateDocumentTypeCommand" /> implementation.</param>
public class UpdateDocumentTypeScenario(
    IUpdateDocumentTypeCommand updateDocumentTypeCommand
) : IHaveInputAndResultSaga<DocumentTypeResult, UpdateDocumentTypeScenarioContext>
{
    public async Task<Option<DocumentTypeResult>> ExecuteAsync(
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