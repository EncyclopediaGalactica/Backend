namespace Common.Sagas;

public interface IScenarioContextWithPayload<T> : ISagaContext
{
    T? Payload { get; set; }
}