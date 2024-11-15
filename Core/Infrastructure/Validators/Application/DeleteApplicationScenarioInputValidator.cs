namespace EncyclopediaGalactica.Core.Infrastructure.Validators.Application;

using BusinessLogic.Contracts;

using FluentValidation;

public class DeleteApplicationScenarioInputValidator : AbstractValidator<ApplicationInput>
{
    public DeleteApplicationScenarioInputValidator()
    {
        RuleFor(a => a.Id).GreaterThanOrEqualTo(1);
    }
}