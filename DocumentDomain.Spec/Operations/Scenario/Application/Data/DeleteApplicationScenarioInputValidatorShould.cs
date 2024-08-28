namespace DocumentDomain.Spec.Operations.Scenario.Application.Data;

using EncyclopediaGalactica.BusinessLogic.Contracts;
using FluentAssertions;
using FluentValidation;
using Infrastructure.Validators.Application;

public class DeleteApplicationScenarioInputValidatorShould
{
    private readonly DeleteApplicationScenarioInputValidator _validator = new();

    [Fact]
    public async Task Throw_WhenInputIsInvalid()
    {
        Func<Task> f = async () => { await _validator.ValidateAndThrowAsync(new ApplicationInput { Id = 0 }); };
        await f.Should().ThrowExactlyAsync<ValidationException>();
    }
}