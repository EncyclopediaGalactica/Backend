#region

using DocumentDomain.Contracts;
using DocumentDomain.Entity;

#endregion

namespace DocumentDomain.Infrastructure.Mappers;

public interface IRelationMapper
{
    Relation MapRelationInputToRelation(RelationInput payload);
    RelationResult MapRelationToRelationResult(Relation result);
    List<RelationResult> MapRelationsToRelationResults(List<Relation> result);
}