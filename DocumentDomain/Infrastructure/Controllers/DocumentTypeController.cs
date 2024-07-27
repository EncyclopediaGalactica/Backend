namespace DocumentDomain.Infrastructure.Controllers;

using EncyclopediaGalactica.BusinessLogic.Contracts;
using Microsoft.AspNetCore.Mvc;
using Operations.Scenarios.DocumentType;

[ApiController]
[Route("api/document")]
public class DocumentTypeController(
    GetDocumentTypesScenario getDocumentTypesScenario,
    AddDocumentTypeScenario addDocumentTypeScenario,
    UpdateDocumentTypeScenario updateDocumentTypeScenario
)
{
    [HttpGet]
    [Route("documentType")]
    public async Task<IActionResult> GetDocumentTypesAsync(CancellationToken cancellationToken = default)
    {
        GetDocumentTypesScenarioContext ctx = new GetDocumentTypesScenarioContext();
        List<DocumentTypeResult> result = await getDocumentTypesScenario.ExecuteAsync(
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
        AddDocumentTypeScenarioContext ctx = new AddDocumentTypeScenarioContext
        {
            Payload = input
        };
        DocumentTypeResult result = await addDocumentTypeScenario.ExecuteAsync(ctx, cancellationToken);
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
        UpdateDocumentTypeScenarioContext ctx = new UpdateDocumentTypeScenarioContext
        {
            Payload = input
        };
        DocumentTypeResult result = await updateDocumentTypeScenario.ExecuteAsync(
            ctx,
            cancellationToken).ConfigureAwait(false);
        return new OkObjectResult(result);
    }
}