namespace DocumentDomain.Spec.Operations.Sagas;

using Contracts;
using FluentAssertions;
using FluentValidation.Results;
using Infrastructure.Validators;

public class AddDocumentSagaInputValidatorShould
{
    private readonly AddDocumentSagaInputValidator AddDocumentSagaInputValidator;

    public AddDocumentSagaInputValidatorShould()
    {
        AddDocumentSagaInputValidator = new AddDocumentSagaInputValidator();
    }

    [Theory]
    [ClassData(typeof(AddDocumentSagaInputInvalidData))]
    public void IndicateTheInputIsInvalid(DocumentInput documentInput)
    {
        ValidationResult? res = AddDocumentSagaInputValidator.Validate(documentInput);
        res.IsValid.Should().BeFalse();
    }

    [Theory]
    [ClassData(typeof(AddDocumentSagaInputValidData))]
    public void IndicateTheInputIsValid(DocumentInput documentInput)
    {
        ValidationResult? res = AddDocumentSagaInputValidator.Validate(documentInput);
        res.IsValid.Should().BeTrue();
    }
}