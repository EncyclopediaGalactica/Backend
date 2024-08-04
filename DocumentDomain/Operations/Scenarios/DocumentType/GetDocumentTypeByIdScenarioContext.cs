namespace DocumentDomain.Operations.Scenarios.DocumentType;

using Common.Sagas;

public class GetDocumentTypeByIdScenarioContext : ISagaContextWithPayload<long>
{
    public long Payload { get; set; }
}