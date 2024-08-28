namespace DocumentDomain.Spec.Operations.Scenario.Application;

using Data;
using EncyclopediaGalactica.BusinessLogic.Contracts;
using FluentAssertions;
using FluentValidation;
using Infrastructure.Validators.Application;

public class AddApplicationScenarioInputValidatorShould
{
    private readonly AddApplicationScenarioInputValidator _validator = new();

    [Theory]
    [ClassData(typeof(AddApplicationScenarioInvalidInputData))]
    public void Throw_WhenInputIsInvalid(ApplicationInput input)
    {
        Func<Task> f = async () => { await _validator.ValidateAndThrowAsync(input); };

        f.Should().ThrowExactlyAsync<ValidationException>();
    }
}