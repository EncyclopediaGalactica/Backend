namespace DocumentDomain.Spec.Operations.Scenario;

using EncyclopediaGalactica.BusinessLogic.Contracts;
using FluentAssertions;
using FluentValidation.Results;
using Infrastructure.Validators;

public class AddDocumentScenarioInputValidatorShould
{
    private readonly AddDocumentScenarioInputValidator _addDocumentScenarioInputValidator = new();

    [Theory]
    [ClassData(typeof(AddDocumentSagaInputInvalidData))]
    public void IndicateTheInputIsInvalid(DocumentInput documentInput)
    {
        ValidationResult? res = _addDocumentScenarioInputValidator.Validate(documentInput);
        res.IsValid.Should().BeFalse();
    }

    [Theory]
    [ClassData(typeof(AddDocumentSagaInputValidData))]
    public void IndicateTheInputIsValid(DocumentInput documentInput)
    {
        ValidationResult? res = _addDocumentScenarioInputValidator.Validate(documentInput);
        res.IsValid.Should().BeTrue();
    }
}