namespace DocumentDomain.Operations.Scenarios;

using Common.Sagas;

public class DeleteDocumentScenarioContext : IScenarioContextWithPayload<Int64>
{
    public Int64 Payload { get; set; }
    public Guid CorrelationId { get; set; }
}