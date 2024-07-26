namespace DocumentDomain.Operations.Sagas;

using Common.Sagas;
using EncyclopediaGalactica.BusinessLogic.Contracts;

public class AddDocumentTypeSaga : IHaveInputAndResultSaga<DocumentTypeResult, AddDocumentTypeSagaContext>
{
    public Task<DocumentTypeResult> ExecuteAsync(AddDocumentTypeSagaContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}