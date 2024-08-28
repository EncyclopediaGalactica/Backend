namespace DocumentDomain.Spec.Operations.Scenario.Application;

using DocumentDomain.Operations.Scenarios.Application;
using EncyclopediaGalactica.BusinessLogic.Contracts;
using FluentAssertions;
using LanguageExt;

public class GetApplicationsScenarioShould : ScenarioBaseTest
{
    [Fact]
    public async Task Return_SomeAndListOfItemsWhenThereAreItemsInTheDatabase()
    {
        int expectedVolume = 3;
        await SeedAndForgetApplications(expectedVolume);
        Option<List<ApplicationResult>> result = await GetApplicationsScenario.ExecuteAsync(new GetApplicationsScenarioContext
        {
            CorrelationId = Guid.NewGuid()
        });
        result.IsSome.Should().BeTrue();
        result.IfSome(result => { result.Count.Should().Be(expectedVolume); });
    }

    [Fact]
    public async Task Return_SomeAndEmptyListWhenThereAreNoItemsInTheDatabase()
    {
        Option<List<ApplicationResult>> result = await GetApplicationsScenario.ExecuteAsync(new GetApplicationsScenarioContext
        {
            CorrelationId = Guid.NewGuid()
        });
        result.IsSome.Should().BeTrue();
        result.IfSome(result => { result.Count.Should().Be(0); });
    }
}