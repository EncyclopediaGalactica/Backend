namespace DocumentDomain.Spec.Operations.Sagas;

using Common.Sagas;
using Contracts;
using DocumentDomain.Operations.Sagas;
using FluentAssertions;

public class AddDocumentSagaShould : SagaBaseTest
{
    [Fact]
    public async Task AddDocument()
    {
        DocumentInput input = new DocumentInput
        {
            Name = "name",
            Description = "description"
        };
        AddDocumentSagaContext ctx = new AddDocumentSagaContext
        {
            Payload = input
        };
        DocumentResult result = await AddDocumentSaga.ExecuteAsync(ctx);

        result.Should().NotBeNull();
        result.Id.Should().BeGreaterThanOrEqualTo(1);
        result.Name.Should().Be(input.Name);
        result.Description.Should().Be(input.Description);
    }

    [Theory]
    [ClassData(typeof(AddDocumentSagaInputInvalidData))]
    public async Task ThrowWhenInputIsInvalid(DocumentInput documentInput)
    {
        AddDocumentSagaContext ctx = new AddDocumentSagaContext
        {
            Payload = documentInput
        };
        Func<Task> task = async () => { await AddDocumentSaga.ExecuteAsync(ctx); };
        await task.Should().ThrowExactlyAsync<SagaException>();
    }
}