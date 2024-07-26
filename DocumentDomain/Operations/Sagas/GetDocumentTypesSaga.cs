namespace DocumentDomain.Operations.Sagas;

using Commands;
using Common.Sagas;
using EncyclopediaGalactica.BusinessLogic.Contracts;

public class GetDocumentTypesSaga(
    IGetDocumentTypesCommand getDocumentTypesCommand) : IHaveResultSaga<List<DocumentTypeResult>>
{
    public async Task<List<DocumentTypeResult>> ExecuteAsync(
        ISagaContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            return await getDocumentTypesCommand.ExecuteAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}