using Common.Validators;
using DocumentDomain.Contracts;
using FluentValidation;

namespace EncyclopediaGalactica.BusinessLogic.Validators;

public class DocumentInputValidator : AbstractValidator<DocumentInput>
{
    public DocumentInputValidator()
    {
        RuleSet(Operations.Add, () =>
        {
            RuleFor(p => p.Id).Equal(0);
            RuleFor(p => p.Name).NotNull().NotEmpty();
            RuleFor(p => p.Description).NotEmpty();
            When(prop => !string.IsNullOrEmpty(prop.Name),
                () => { RuleFor(p => p.Name.Trim().Length).GreaterThanOrEqualTo(3); });
            When(prop => !string.IsNullOrEmpty(prop.Description),
                () => { RuleFor(p => p.Description.Trim()).NotEmpty(); });
        });

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