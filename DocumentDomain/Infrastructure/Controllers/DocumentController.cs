namespace DocumentDomain.Infrastructure.Controllers;

using EncyclopediaGalactica.BusinessLogic.Contracts;
using Microsoft.AspNetCore.Mvc;
using Operations.Sagas;

[ApiController]
[Route("api/document")]
public class DocumentController(
    GetDocumentsSaga getDocumentsSaga)
{
    [HttpGet]
    [Route("getDocuments")]
    public async Task<IActionResult> GetDocumentsAsync()
    {
        GetDocumentsSagaContext ctx = new GetDocumentsSagaContext();
        List<DocumentResult> result = await getDocumentsSaga.ExecuteAsync(ctx).ConfigureAwait(false);
        return new OkObjectResult(result);
    }
}