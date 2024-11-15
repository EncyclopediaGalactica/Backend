namespace EncyclopediaGalactica.Core.Application;

using Common;

using FluentValidation;
using FluentValidation.Results;

using LanguageExt;

using Microsoft.EntityFrameworkCore;

public class GetApplicationByIdScenario(
    GetApplicationByIdScenarioInputValidator  validator,
    DbContextOptions<DocumentDomainDbContext> dbContextOptions
)
{
    public Either<ErrorResult, ApplicationResult> Execute(GetApplicationByIdScenarioContext context)
    {
        Either<ErrorResult, ApplicationResult> operationResult =
            from validatedInput in ValidateInput(context)
            from entityFromStorage in GetEntityFromStrorage(validatedInput, context)
            from mappedResultEntity in MapEntityToResult(entityFromStorage)
            select mappedResultEntity;
        return operationResult;
    }

    private static Either<ErrorResult, ApplicationResult> MapEntityToResult(Application application) =>
        Either<ErrorResult, ApplicationResult>.Right(application.ToApplicationResult());

    private Either<ErrorResult, Application> GetEntityFromStrorage(
        ApplicationInput                  input,
        GetApplicationByIdScenarioContext context)
    {
        using DocumentDomainDbContext ctx = new(dbContextOptions);
        try
        {
            Application target = ctx.Applications.First(w => w.Id == input.Id);
            return Either<ErrorResult, Application>.Right(target);
        }
        catch (Exception e)
        {
            return Either<ErrorResult, Application>.Left(new ErrorResult(
                                                             context.CorrelationId,
                                                             e.Message
                                                         ));
        }
    }

    public Either<ErrorResult, ApplicationInput> ValidateInput(GetApplicationByIdScenarioContext context)
    {
        if (context.Payload is null)
        {
            return Either<ErrorResult, ApplicationInput>.Left(new ErrorResult(
                                                                  context.CorrelationId,
                                                                  "Validation error"
                                                              ));
        }

        ValidationResult validationResult = validator.Validate(context.Payload);
        if (validationResult.IsValid)
        {
            return Either<ErrorResult, ApplicationInput>.Right(context.Payload);
        }

        return Either<ErrorResult, ApplicationInput>.Left(new ErrorResult(
                                                              context.CorrelationId,
                                                              validationResult.Errors.ToSummarize()
                                                          ));
    }
}

public class GetApplicationByIdScenarioInputValidator : AbstractValidator<ApplicationInput>
{
    public GetApplicationByIdScenarioInputValidator()
    {
        RuleFor(i => i.Id)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Id must be greater than or equal to 1.");
    }
}

public record GetApplicationByIdScenarioContext(Guid CorrelationId, ApplicationInput Payload);
