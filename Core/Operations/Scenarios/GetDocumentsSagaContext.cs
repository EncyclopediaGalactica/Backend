namespace EncyclopediaGalactica.Core.Operations.Scenarios;

using Common.Scenario;

public class GetDocumentsSagaContext : ISagaContext
{
    public Guid CorrelationId { get; set; }
}