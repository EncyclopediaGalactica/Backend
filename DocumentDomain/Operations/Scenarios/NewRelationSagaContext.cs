namespace DocumentDomain.Operations.Scenarios;

using Common.Sagas;
using EncyclopediaGalactica.BusinessLogic.Contracts;

public class NewRelationSagaContext : ISagaContextWithPayload<RelationInput>
{
    public RelationInput Payload { get; set; }
}