namespace Common.Sagas;

public interface ISagaContextWithPayload<T> : ISagaContext
{
    T Payload { get; set; }
}