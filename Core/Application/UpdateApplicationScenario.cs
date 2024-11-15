namespace EncyclopediaGalactica.Core.Application;

using Common;

using FluentValidation;
using FluentValidation.Results;

using LanguageExt;

using Microsoft.EntityFrameworkCore;

public class UpdateApplicationScenario(
    UpdateApplicationScenarioInputValidator   validator,
    DbContextOptions<DocumentDomainDbContext> dbContextOptions
)
{
    public Either<ErrorResult, ApplicationResult> Execute(UpdateApplicationScenarioContext context)
    {
        Either<ErrorResult, ApplicationResult> operationResult =
            from validatedInput in ValidateInput(context)
            from mappedInput in MapInputToEntity(validatedInput)
            from updatedEntity in UpdateEntityInStorage(mappedInput, context)
            from mapUpdatedEntity in MapUpdatedEntityToResult(updatedEntity)
            select mapUpdatedEntity;
        return operationResult;
    }

    private static Either<ErrorResult, ApplicationResult> MapUpdatedEntityToResult(Application application) =>
        Either<ErrorResult, ApplicationResult>.Right(application.ToApplicationResult());

    private Either<ErrorResult, Application> UpdateEntityInStorage(
        Application                      input,
        UpdateApplicationScenarioContext context
    )
    {
        using DocumentDomainDbContext ctx = new(dbContextOptions);
        try
        {
            Application target = ctx.Applications.First(w => w.Id == input.Id);
            target.Name             = input.Name;
            target.Description      = input.Description;
            ctx.Entry(target).State = EntityState.Modified;
            ctx.SaveChanges();
            return Either<ErrorResult, Application>.Right(target);
        }
        catch (Exception e)
        {
            return Either<ErrorResult, Application>.Left(
                new ErrorResult(context.CorrelationId, e.Message)
            );
        }
    }

    private static Either<ErrorResult, Application> MapInputToEntity(ApplicationInput input) =>
        Either<ErrorResult, Application>.Right(input.ToApplication());


    private Either<ErrorResult, ApplicationInput> ValidateInput(
        UpdateApplicationScenarioContext context
    )
    {
        if (context.Payload is null)
        {
            return Either<ErrorResult, ApplicationInput>.Left(
                new ErrorResult(context.CorrelationId, "Validation error"));
        }

        ValidationResult validationResult = validator.Validate(context.Payload);

        if (validationResult.IsValid)
        {
            return Either<ErrorResult, ApplicationInput>.Right(context.Payload);
        }

        return Either<ErrorResult, ApplicationInput>.Left(
            new ErrorResult(context.CorrelationId, validationResult.Errors.ToSummarize()));
    }
}

public class UpdateApplicationScenarioInputValidator : AbstractValidator<ApplicationInput>
{
    public UpdateApplicationScenarioInputValidator()
    {
        RuleFor(i => i.Id)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Id must be zero greater than or equal to 1.");

        RuleFor(i => i.Name)
            .NotEmpty()
            .WithMessage("Name must not be empty");
        RuleFor(i => i.Name.Trim().Length())
            .GreaterThanOrEqualTo(3)
            .LessThanOrEqualTo(255)
            .WithMessage("Trimmed name length must be between 3 and 255 characters");


        RuleFor(i => i.Description)
            .NotEmpty()
            .WithMessage("Name must not be empty");
        RuleFor(i => i.Description.Trim().Length())
            .GreaterThanOrEqualTo(3)
            .LessThanOrEqualTo(255)
            .WithMessage("Trimmed name length must be between 3 and 255 characters");
    }
}

public record UpdateApplicationScenarioContext(Guid CorrelationId, ApplicationInput? Payload);
