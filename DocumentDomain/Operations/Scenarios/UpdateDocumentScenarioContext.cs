namespace DocumentDomain.Operations.Scenarios;

using Common.Sagas;
using EncyclopediaGalactica.BusinessLogic.Contracts;

public class UpdateDocumentScenarioContext : IScenarioContextWithPayload<DocumentInput>
{
    public DocumentInput Payload { get; set; }
    public Guid CorrelationId { get; set; }
}