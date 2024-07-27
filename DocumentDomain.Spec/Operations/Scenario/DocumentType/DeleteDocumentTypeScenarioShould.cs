namespace DocumentDomain.Spec.Operations.Scenario.DocumentType;

using Data;
using DocumentDomain.Operations.Scenarios.DocumentType;
using EncyclopediaGalactica.BusinessLogic.Contracts;
using FluentAssertions;

public class DeleteDocumentTypeScenarioShould : ScenarioBaseTest
{
    [Theory]
    [ClassData(typeof(DeleteDocumentTypeScenarioInputInvalidData))]
    public async Task Throw_WhenInputIsInvalid(DocumentTypeInput input)
    {
        Func<Task> f = async () =>
        {
            await DeleteDocumentTypeScenario.ExecuteAsync(
                new DeleteDocumentTypeScenarioContext { Payload = input });
        };
        await f.Should().ThrowAsync<Exception>();
    }

    [Fact]
    public async Task Delete_WhenInputIsValid()
    {
        DocumentTypeInput tbd = new DocumentTypeInput { Name = "tbd name", Description = "tbd desc" };
        DocumentTypeResult res = await AddDocumentTypeScenario.ExecuteAsync(
            new AddDocumentTypeScenarioContext { Payload = tbd });

        DocumentTypeInput delete = new DocumentTypeInput { Id = res.Id };
        await DeleteDocumentTypeScenario.ExecuteAsync(
            new DeleteDocumentTypeScenarioContext { Payload = delete });

        List<DocumentTypeResult> result = await GetDocumentTypesScenario.ExecuteAsync(
            new GetDocumentTypesScenarioContext());
        result.Where(p => p.Id == res.Id).ToList().Count.Should().Be(0);
    }
}