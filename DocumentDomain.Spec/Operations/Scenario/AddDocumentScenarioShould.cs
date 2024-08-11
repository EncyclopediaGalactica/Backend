namespace DocumentDomain.Spec.Operations.Scenario;

using Common.Sagas;
using DocumentDomain.Operations.Scenarios;
using EncyclopediaGalactica.BusinessLogic.Contracts;
using FluentAssertions;

public class AddDocumentScenarioShould : ScenarioBaseTest
{
    [Fact]
    public async Task AddDocument()
    {
        DocumentInput input = new DocumentInput
        {
            Name = "name",
            Description = "description"
        };
        AddDocumentScenarioContext ctx = new AddDocumentScenarioContext
        {
            Payload = input
        };
        DocumentResult result = await AddDocumentSaga.ExecuteAsync(ctx).IfNoneAsync(new DocumentResult());

        result.Should().NotBeNull();
        result.Id.Should().BeGreaterThanOrEqualTo(1);
        result.Name.Should().Be(input.Name);
        result.Description.Should().Be(input.Description);
    }

    [Theory]
    [ClassData(typeof(AddDocumentSagaInputInvalidData))]
    public async Task ThrowWhenInputIsInvalid(DocumentInput documentInput)
    {
        AddDocumentScenarioContext ctx = new AddDocumentScenarioContext
        {
            Payload = documentInput
        };
        Func<Task> task = async () => { await AddDocumentSaga.ExecuteAsync(ctx); };
        await task.Should().ThrowExactlyAsync<SagaException>();
    }
}