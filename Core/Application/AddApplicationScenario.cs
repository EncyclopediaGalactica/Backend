namespace EncyclopediaGalactica.Core.Application;

using Common.Validation;

using FluentValidation;
using FluentValidation.Results;

using Infrastructure.Database;

using LanguageExt;

using Microsoft.EntityFrameworkCore;

using Operations.Scenarios;

public class AddApplicationScenario(
    DbContextOptions<DocumentDomainDbContext> dbContextOptions,
    AddApplicationScenarioInputValidator validator)
{
    public Either<ErrorResult, ApplicationResult> Execute(
        AddApplicationScenarioContext context,
        CancellationToken cancellationToken = default
    )
    {
        Either<ErrorResult, ApplicationResult> result =
            from validatedInput in ValidateInput(context)
            from mappedInput in MapInputToEntity(context)
            from createdEntity in CreateNewEntityInStorage(mappedInput, context, cancellationToken)
            from mappedResult in MapResultToContract(createdEntity, context)
            select mappedResult;

        return result;
    }

    private Either<ErrorResult, ApplicationResult> MapResultToContract(
        Application createdEntity,
        AddApplicationScenarioContext context) =>
        createdEntity.ToApplicationResult();

    private Either<ErrorResult, Application> CreateNewEntityInStorage(
        Application mappedInput,
        AddApplicationScenarioContext context,
        CancellationToken cancellationToken)
    {
        using DocumentDomainDbContext ctx = new(dbContextOptions);
        try
        {
            ctx.Applications.Add(mappedInput);
            ctx.SaveChanges();
            return Either<ErrorResult, Application>.Right(mappedInput);
        }
        catch (Exception e)
        {
            return Either<ErrorResult, Application>.Left(new ErrorResult(context.CorrelationId, e.Message));
        }
    }

    private Either<ErrorResult, Application> MapInputToEntity(AddApplicationScenarioContext context) =>
        context.Payload!.ToApplication();

    private Either<ErrorResult, ApplicationInput> ValidateInput(AddApplicationScenarioContext context)
    {
        if (context.Payload == null)
        {
            return Either<ErrorResult, ApplicationInput>.Left(
                new ErrorResult(context.CorrelationId, "No payload were provided"));
        }

        ValidationResult validationResult = validator.Validate(context.Payload);
        if (validationResult.IsValid)
        {
            return Either<ErrorResult, ApplicationInput>.Right(context.Payload);
        }

        return Either<ErrorResult, ApplicationInput>.Left(new ErrorResult(context.CorrelationId,
                                                                          validationResult.Errors.ToSummarize()));
    }
}

public class AddApplicationScenarioInputValidator : AbstractValidator<ApplicationInput>
{
    public AddApplicationScenarioInputValidator()
    {
        RuleFor(i => i.Id)
            .Equal(0)
            .WithMessage("Id must be zero.");

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

public record AddApplicationScenarioContext(Guid CorrelationId, ApplicationInput? Payload);
