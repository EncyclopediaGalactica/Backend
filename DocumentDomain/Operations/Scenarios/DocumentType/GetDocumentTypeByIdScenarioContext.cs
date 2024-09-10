namespace EncyclopediaGalactica.DocumentDomain.Operations.Scenarios.DocumentType;

using Common.Sagas;

public class GetDocumentTypeByIdScenarioContext : IHavePayloadScenarioContext<long>
{
    public long Payload { get; set; }
    public Guid CorrelationId { get; set; }
}