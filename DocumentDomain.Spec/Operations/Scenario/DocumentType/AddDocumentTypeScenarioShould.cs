namespace DocumentDomain.Spec.Operations.Scenario.DocumentType;

using Data;
using DocumentDomain.Operations.Scenarios.DocumentType;
using EncyclopediaGalactica.BusinessLogic.Contracts;
using FluentAssertions;

public class AddDocumentTypeScenarioShould : ScenarioBaseTest
{
    [Theory]
    [ClassData(typeof(AddDocumentTypeScenarioInputInvalidData))]
    public async Task Throw_WhenInputIsInvalid(DocumentTypeInput input)
    {
        Func<Task> f = async () =>
        {
            await AddDocumentTypeScenario.ExecuteAsync(
                new AddDocumentTypeScenarioContext { Payload = input }
            );
        };
        await f.Should().ThrowAsync<Exception>();
    }

    [Theory]
    [ClassData(typeof(AddDocumentTypeScenarioInputValidData))]
    public async Task Create_WhenInputIsValid(DocumentTypeInput input)
    {
        DocumentTypeResult result = await AddDocumentTypeScenario.ExecuteAsync(
            new AddDocumentTypeScenarioContext { Payload = input });

        result.Id.Should().BeGreaterThanOrEqualTo(1);
        result.Name.Should().Be(input.Name);
        result.Description.Should().Be(input.Description);
    }
}