namespace DocumentDomain.Infrastructure.Validators;

using Common.Validators;
using Contracts;
using FluentValidation;

public class DocumentInputValidator : AbstractValidator<DocumentInput>
{
    public DocumentInputValidator()
    {
        RuleSet(Operations.Update, () =>
        {
            RuleFor(p => p.Id).GreaterThanOrEqualTo(1);
            RuleFor(p => p.Name).NotNull().NotEmpty();
            RuleFor(p => p.Description).NotNull().NotEmpty();
            When(prop => !string.IsNullOrEmpty(prop.Name),
                () => { RuleFor(p => p.Name.Trim().Length).GreaterThanOrEqualTo(3); });
            When(prop => !string.IsNullOrEmpty(prop.Description),
                () => { RuleFor(p => p.Description.Trim().Length).NotEmpty(); });
        });
    }
}