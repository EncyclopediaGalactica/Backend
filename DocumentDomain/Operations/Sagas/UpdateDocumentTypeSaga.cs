namespace DocumentDomain.Operations.Sagas;

using Common.Sagas;
using EncyclopediaGalactica.BusinessLogic.Contracts;

public class UpdateDocumentTypeSaga : IHaveInputAndResultSaga<DocumentTypeResult, UpdateDocumentTypeSagaContext>
{
    public Task<DocumentTypeResult> ExecuteAsync(UpdateDocumentTypeSagaContext context,
        CancellationToken cancellationToken = default)
    {
    }
}