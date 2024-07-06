#region

using DocumentDomain.Contracts;
using FluentValidation;

#endregion

namespace DocumentDomain.Infrastructure.Validators;

public class DocumentStructureNodeInputValidator : AbstractValidator<DocumentStructureNodeInput>
{
    public DocumentStructureNodeInputValidator()
    {
        RuleSet(Common.Validators.Operations.Add, () =>
        {
            RuleFor(p => p.Id)
                .Equal(0)
                .WithMessage("Id must be zero.");
            RuleFor(p => p.DocumentId)
                .GreaterThan(0)
                .WithMessage("Document Id must not be zero");
        });
    }
}