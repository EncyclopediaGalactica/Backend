namespace DocumentDomain.Infrastructure.Validators.Application;

using EncyclopediaGalactica.BusinessLogic.Contracts;
using FluentValidation;

public class DeleteApplicationScenarioInputValidator : AbstractValidator<ApplicationInput>
{
    public DeleteApplicationScenarioInputValidator()
    {
        RuleFor(a => a.Id).GreaterThanOrEqualTo(1);
    }
}