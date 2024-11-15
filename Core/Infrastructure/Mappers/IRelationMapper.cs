namespace EncyclopediaGalactica.Core.Infrastructure.Mappers;

using BusinessLogic.Contracts;

using Entity;

public interface IRelationMapper
{
    Relation MapRelationInputToRelation(RelationInput                 payload);
    RelationResult MapRelationToRelationResult(Relation               result);
    List<RelationResult> MapRelationsToRelationResults(List<Relation> result);
}