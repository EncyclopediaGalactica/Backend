namespace EncyclopediaGalactica.Core.Operations.Scenarios.DocumentType;

using BusinessLogic.Contracts;
using FluentValidation;

/// <summary>
///     Input data validator of the <see cref="DeleteDocumentTypeScenario" />.
/// </summary>
public class DeleteDocumentTypeScenarioInputValidator : AbstractValidator<DocumentTypeInput>
{
    public DeleteDocumentTypeScenarioInputValidator()
    {
        RuleFor(p => p.Id).GreaterThanOrEqualTo(1);
    }
}