namespace EncyclopediaGalactica.Core.Operations.Scenarios.DocumentType;

using Common.Scenario;

public class GetDocumentTypeByIdScenarioContext : IHavePayloadScenarioContext<long>
{
    public long Payload { get; set; }
    public Guid CorrelationId { get; set; }
}