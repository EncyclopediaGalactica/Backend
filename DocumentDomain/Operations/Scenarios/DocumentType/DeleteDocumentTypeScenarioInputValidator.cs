namespace DocumentDomain.Operations.Scenarios.DocumentType;

using EncyclopediaGalactica.BusinessLogic.Contracts;
using FluentValidation;

public class DeleteDocumentTypeScenarioInputValidator : AbstractValidator<DocumentTypeInput>
{
    public DeleteDocumentTypeScenarioInputValidator()
    {
        RuleFor(p => p.Id).GreaterThanOrEqualTo(1);
    }
}