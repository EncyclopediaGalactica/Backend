namespace DocumentDomain.Infrastructure.Validators;

using Common.Validators;
using Contracts;
using FluentValidation;

public class ApplicationInputValidator : AbstractValidator<ApplicationInput>
{
    public ApplicationInputValidator()
    {
        RuleSet(Operations.Add, () =>
        {
            RuleFor(r => r.Id).Equal(0);
            RuleFor(r => r.Name.Trim().Length).GreaterThanOrEqualTo(3);
        });

        RuleSet(Operations.Delete, () => { RuleFor(r => r.Id).GreaterThanOrEqualTo(1); });

        RuleSet(Operations.Update, () =>
        {
            RuleFor(r => r.Id).GreaterThanOrEqualTo(1);
            RuleFor(r => r.Name.Trim().Length).GreaterThanOrEqualTo(3);
        });
    }
}