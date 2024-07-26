namespace DocumentDomain.Operations.Sagas;

using Common.Sagas;
using EncyclopediaGalactica.BusinessLogic.Contracts;

public class EditRelationSagaContext : ISagaContextWithPayload<RelationInput>
{
    public RelationInput Payload { get; set; }
}