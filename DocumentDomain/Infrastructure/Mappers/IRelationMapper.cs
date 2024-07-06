#region

using DocumentDomain.Contracts;
using EncyclopediaGalactica.BusinessLogic.Entities;

#endregion

namespace EncyclopediaGalactica.BusinessLogic.Mappers;

public interface IRelationMapper
{
    Relation MapRelationInputToRelation(RelationInput payload);
    RelationResult MapRelationToRelationResult(Relation result);
    List<RelationResult> MapRelationsToRelationResults(List<Relation> result);
}