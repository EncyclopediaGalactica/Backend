namespace Common.Sagas;

public interface ISagaContext
{
    Guid CorrelationId { get; set; }
}