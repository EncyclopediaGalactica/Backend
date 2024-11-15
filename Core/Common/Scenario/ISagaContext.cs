namespace EncyclopediaGalactica.Core.Common.Scenario;

public interface ISagaContext
{
    Guid CorrelationId { get; set; }
}