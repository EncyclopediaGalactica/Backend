namespace EncyclopediaGalactica.DocumentDomain.Operations.Scenarios.RelationType;

using BusinessLogic.Contracts;
using Entity;

public static class RelationTypeMappers
{
    public static RelationType MapToRelationType(this RelationTypeInput input)
    {
        return new RelationType
        {
            Id = input.Id,
            Name = input.Name,
            Description = input.Description
        };
    }

    public static RelationTypeResult MapToRelationTypeResult(this RelationType relationType)
    {
        return new RelationTypeResult
        {
            Id = relationType.Id,
            Name = relationType.Name,
            Description = relationType.Description
        };
    }
}