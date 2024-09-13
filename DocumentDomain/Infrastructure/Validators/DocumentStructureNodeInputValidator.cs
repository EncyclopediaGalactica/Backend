namespace EncyclopediaGalactica.DocumentDomain.Infrastructure.Validators;

using Common.Validators;
using EncyclopediaGalactica.BusinessLogic.Contracts;
using FluentValidation;

public class DocumentStructureNodeInputValidator : AbstractValidator<DocumentStructureNodeInput>
{
    public DocumentStructureNodeInputValidator()
    {
        RuleSet(Operations.Add, () =>
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