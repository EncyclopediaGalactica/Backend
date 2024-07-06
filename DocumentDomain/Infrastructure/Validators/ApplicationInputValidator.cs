using DocumentDomain.Contracts;
using FluentValidation;

namespace DocumentDomain.Infrastructure.Validators;

public class ApplicationInputValidator : AbstractValidator<ApplicationInput>
{
    public ApplicationInputValidator()
    {
        RuleSet(Common.Validators.Operations.Add, () =>
        {
            RuleFor(r => r.Id).Equal(0);
            RuleFor(r => r.Name.Trim().Length).GreaterThanOrEqualTo(3);
        });

        RuleSet(Common.Validators.Operations.Delete, () => { RuleFor(r => r.Id).GreaterThanOrEqualTo(1); });

        RuleSet(Common.Validators.Operations.Update, () =>
        {
            RuleFor(r => r.Id).GreaterThanOrEqualTo(1);
            RuleFor(r => r.Name.Trim().Length).GreaterThanOrEqualTo(3);
        });
    }
}