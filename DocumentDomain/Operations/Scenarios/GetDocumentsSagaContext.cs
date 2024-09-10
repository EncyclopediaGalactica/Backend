namespace EncyclopediaGalactica.DocumentDomain.Operations.Scenarios;

using Common.Sagas;

public class GetDocumentsSagaContext : ISagaContext
{
    public Guid CorrelationId { get; set; }
}