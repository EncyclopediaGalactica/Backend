namespace EncyclopediaGalactica.Core.Infrastructure.Validators.Application;

using BusinessLogic.Contracts;

using FluentValidation;

public class GetApplicationByIdValidator : AbstractValidator<ApplicationInput>
{
    public GetApplicationByIdValidator()
    {
        RuleFor(f => f.Id).GreaterThanOrEqualTo(0);
    }
}