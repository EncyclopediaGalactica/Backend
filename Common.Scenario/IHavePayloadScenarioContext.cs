namespace Common.Sagas;

public interface IHavePayloadScenarioContext<T> : ISagaContext
{
    T? Payload { get; set; }
}