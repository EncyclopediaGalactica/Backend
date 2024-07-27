namespace DocumentDomain.Spec.Operations.Scenario.DocumentType;

using Data;
using DocumentDomain.Operations.Scenarios.DocumentType;
using EncyclopediaGalactica.BusinessLogic.Contracts;
using FluentAssertions;
using FluentValidation.Results;

public class AddDocumentTypeScenarioInputValidatorShould
{
    private readonly AddDocumentTypeScenarioInputValidator _validator = new();

    [Theory]
    [ClassData(typeof(AddDocumentTypeScenarioInputInvalidData))]
    public void IndicateInvalidInput(DocumentTypeInput input)
    {
        ValidationResult result = _validator.Validate(input);
        result.IsValid.Should().BeFalse();
    }

    [Theory]
    [ClassData(typeof(AddDocumentTypeScenarioInputValidData))]
    public void IndicateValidaInput(DocumentTypeInput input)
    {
        ValidationResult? result = _validator.Validate(input);
        result.IsValid.Should().BeTrue();
    }
}