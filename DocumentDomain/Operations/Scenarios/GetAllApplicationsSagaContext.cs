namespace EncyclopediaGalactica.DocumentDomain.Operations.Scenarios;

using Common.Sagas;

public class GetAllApplicationsSagaContext : ISagaContext
{
    public Guid CorrelationId { get; set; }
}