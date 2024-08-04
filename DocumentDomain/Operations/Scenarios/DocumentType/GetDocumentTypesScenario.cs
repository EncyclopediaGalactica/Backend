namespace DocumentDomain.Operations.Scenarios.DocumentType;

using Commands;
using Common.Sagas;
using EncyclopediaGalactica.BusinessLogic.Contracts;
using LanguageExt;

/// <summary>
///     Get the list of <see cref="DocumentType" /> entites.
///     <remarks>
///         The scenario provides a single method Api to safely execute the operation for the list of available
///         <see cref="DocumentType" /> entities.
///     </remarks>
/// </summary>
/// <param name="getDocumentTypesCommand"><see cref="IGetDocumentTypesCommand" /> implelemtation.</param>
public class GetDocumentTypesScenario(
    IGetDocumentTypesCommand getDocumentTypesCommand) : IHaveResultSaga<List<DocumentTypeResult>>
{
    public async Task<Option<List<DocumentTypeResult>>> ExecuteAsync(
        ISagaContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            Option<List<DocumentTypeResult>> result = await getDocumentTypesCommand.ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}