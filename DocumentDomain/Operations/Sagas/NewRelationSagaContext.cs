namespace DocumentDomain.Operations.Sagas;

using Common.Sagas;
using EncyclopediaGalactica.BusinessLogic.Contracts;

public class NewRelationSagaContext : ISagaContextWithPayload<RelationInput>
{
    public RelationInput Payload { get; set; }
}