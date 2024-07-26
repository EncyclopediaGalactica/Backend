namespace DocumentDomain.Infrastructure.Controllers;

using EncyclopediaGalactica.BusinessLogic.Contracts;
using Microsoft.AspNetCore.Mvc;
using Operations.Sagas;

[ApiController]
[Route("api/document")]
public class DocumentTypeController(
    GetDocumentTypesSaga getDocumentTypesSaga,
    AddDocumentTypeSaga addDocumentTypeSaga,
    UpdateDocumentTypeSaga updateDocumentTypeSaga
)
{
    [HttpGet]
    [Route("documentType")]
    public async Task<IActionResult> GetDocumentTypesAsync(CancellationToken cancellationToken = default)
    {
        GetDocumentTypesSagaContext ctx = new GetDocumentTypesSagaContext();
        List<DocumentTypeResult> result = await getDocumentTypesSaga.ExecuteAsync(
            ctx,
            cancellationToken).ConfigureAwait(false);
        return new OkObjectResult(result);
    }

    [HttpPost]
    [Route("documnetType")]
    public async Task<IActionResult> AddDocumnetTypeAsync(
        [FromBody]
        DocumentTypeInput input,
        CancellationToken cancellationToken = default)
    {
        AddDocumentTypeSagaContext ctx = new AddDocumentTypeSagaContext
        {
            Payload = input
        };
        DocumentTypeResult result = await addDocumentTypeSaga.ExecuteAsync(ctx, cancellationToken);
        return new OkObjectResult(result);
    }

    [HttpPut]
    [Route("documentType/{documentTypeId}")]
    public async Task<IActionResult> UpdateDocumentTypeAsync(
        [FromBody]
        DocumentTypeInput input,
        long documentTypeId,
        CancellationToken cancellationToken = default)
    {
        UpdateDocumentTypeSagaContext ctx = new UpdateDocumentTypeSagaContext
        {
            Payload = input
        };
        DocumentTypeResult result = await updateDocumentTypeSaga.ExecuteAsync(
            ctx,
            cancellationToken).ConfigureAwait(false);
        return new OkObjectResult(result);
    }
}