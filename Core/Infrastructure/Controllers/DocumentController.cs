namespace EncyclopediaGalactica.Core.Infrastructure.Controllers;

using BusinessLogic.Contracts;

using LanguageExt;

using Microsoft.AspNetCore.Mvc;

using Operations.Scenarios;

[ApiController]
[Route("api/document")]
public class DocumentController(
    GetDocumentsSaga getDocumentsSaga)
{
    [HttpGet]
    [Route("getDocuments")]
    public async Task<IActionResult> GetDocumentsAsync()
    {
        GetDocumentsSagaContext      ctx    = new();
        Option<List<DocumentResult>> result = await getDocumentsSaga.ExecuteAsync(ctx).ConfigureAwait(false);

        return new OkObjectResult(result
                                      .IfNone(new List<DocumentResult>()));
    }
}