namespace EncyclopediaGalactica.DocumentDomain.Operations.Scenarios;

using Common.Sagas;

public class DeleteDocumentHavePayloadScenarioContext : IHavePayloadScenarioContext<Int64>
{
    public Int64 Payload { get; set; }
    public Guid CorrelationId { get; set; }
}