namespace EncyclopediaGalactica.Core.Application;

using Common;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using Operations.Scenarios;

[ApiController]
[Route("/api/v1/core")]
public class Controllers(
    AddApplicationScenario addApplicationScenario
) : ControllerBase
{
    [HttpGet("/application")]
    public ActionResult<ApplicationResult> AddApplication(
        [FromBody] ApplicationInput applicationInput,
        CancellationToken           cancellationToken = default)
    {
        AddApplicationScenarioContext context = new(
            Guid.NewGuid(),
            applicationInput);
        Either<ErrorResult, ApplicationResult> result = addApplicationScenario.Execute(context, cancellationToken);
        if (result.IsLeft)
        {
            ErrorResponse errorResponse = null;
            result.IfLeft(err =>
            {
                errorResponse = new ErrorResponse(400, err.ErrorMessage, err.CorrelationId.ToString());
            });
            return BadRequest(errorResponse);
        }

        ApplicationResult applicationResult = null;
        result.IfRight(r => applicationResult = r);
        return Created(applicationResult!.Id.ToString(), applicationResult);
    }
}