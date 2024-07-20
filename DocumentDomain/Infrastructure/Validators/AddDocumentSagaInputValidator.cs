namespace DocumentDomain.Infrastructure.Validators;

using Contracts;
using FluentValidation;

public class AddDocumentSagaInputValidator : AbstractValidator<DocumentInput>
{
    public AddDocumentSagaInputValidator()
    {
        RuleFor(p => p.Id).Equal(0);

        RuleFor(p => p.Name).NotNull();
        When(p => p.Name is not null, () =>
        {
            RuleFor(p => p.Name.Trim()).NotEmpty();
            RuleFor(p => p.Name.Trim().Length).GreaterThanOrEqualTo(3);
        });

        RuleFor(p => p.Description).NotNull();
        When(p => p.Description is not null, () =>
        {
            RuleFor(p => p.Description.Trim()).NotEmpty();
            RuleFor(p => p.Description.Trim().Length).GreaterThanOrEqualTo(3);
        });
    }
}