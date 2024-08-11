namespace DocumentDomain.Operations.Scenarios.DocumentType;

using Common.Sagas;

public class GetDocumentTypeByIdScenarioContext : IScenarioContextWithPayload<long>
{
    public long Payload { get; set; }
    public Guid CorrelationId { get; set; }
}