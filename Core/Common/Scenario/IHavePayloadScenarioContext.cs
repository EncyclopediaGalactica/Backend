namespace EncyclopediaGalactica.Core.Common.Scenario;

public interface IHavePayloadScenarioContext<T> : ISagaContext
{
    T? Payload { get; set; }
}