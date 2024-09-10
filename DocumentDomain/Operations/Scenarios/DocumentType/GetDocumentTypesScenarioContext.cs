namespace EncyclopediaGalactica.DocumentDomain.Operations.Scenarios.DocumentType;

using Common.Sagas;

public class GetDocumentTypesScenarioContext : ISagaContext
{
    public Guid CorrelationId { get; set; }
}