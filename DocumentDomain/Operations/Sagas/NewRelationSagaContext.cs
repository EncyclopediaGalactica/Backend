#region

using DocumentDomain.Contracts;
using EncyclopediaGalactica.BusinessLogic.Sagas.Interfaces;

#endregion

namespace EncyclopediaGalactica.BusinessLogic.Sagas.Relation;

public class NewRelationSagaContext : ISagaContextWithPayload<RelationInput>
{
    public RelationInput Payload { get; set; }
}