namespace EncyclopediaGalactica.Core.Infrastructure.Mappers;

using BusinessLogic.Contracts;

using Entity;

public class RelationMapper : IRelationMapper
{
    public Relation MapRelationInputToRelation(RelationInput payload) =>
        new()
        {
            Id      = payload.Id,
            LeftId  = payload.LeftEndId,
            RightId = payload.RightEndId,
        };

    public RelationResult MapRelationToRelationResult(Relation result) =>
        new()
        {
            Id              = result.Id,
            LeftDocumentId  = result.LeftId,
            RightDocumentId = result.RightId,
            // LeftDocument = result.,
            // RightDocument = result.RightEndStructureNodeId
        };

    public List<RelationResult> MapRelationsToRelationResults(List<Relation> r)
    {
        List<RelationResult> result = new();
        r.ForEach(item => result.Add(MapRelationToRelationResult(item)));
        return result;
    }
}