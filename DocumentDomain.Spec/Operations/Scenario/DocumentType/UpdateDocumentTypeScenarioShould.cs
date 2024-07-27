namespace DocumentDomain.Spec.Operations.Scenario.DocumentType;

using Data;
using DocumentDomain.Operations.Scenarios.DocumentType;
using EncyclopediaGalactica.BusinessLogic.Contracts;
using FluentAssertions;

public class UpdateDocumentTypeScenarioShould : ScenarioBaseTest
{
    [Theory]
    [ClassData(typeof(UpdateDocumentTypeScenarioInputInvalidData))]
    public async Task Throw_WhenInputIsInvalid(DocumentTypeInput input)
    {
        Func<Task> f = async () =>
        {
            await UpdateDocumentTypeScenario.ExecuteAsync(
                new UpdateDocumentTypeScenarioContext { Payload = input });
        };

        await f.Should().ThrowAsync<Exception>();
    }

    [Theory]
    [ClassData(typeof(UpdateDocumentTypeScenarioInputValidData))]
    public async Task Create_WhenInputIsValid(DocumentTypeInput input)
    {
        DocumentTypeInput init = new DocumentTypeInput { Name = "init name", Description = "init desc" };
        DocumentTypeResult initResult = await AddDocumentTypeScenario.ExecuteAsync(
            new AddDocumentTypeScenarioContext { Payload = init });

        input.Id = initResult.Id;
        DocumentTypeResult result = await UpdateDocumentTypeScenario.ExecuteAsync(
            new UpdateDocumentTypeScenarioContext { Payload = input });

        result.Id.Should().BeGreaterThanOrEqualTo(1);
        result.Name.Should().Be(input.Name);
        result.Description.Should().Be(input.Description);
    }
}