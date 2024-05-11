namespace EncyclopediaGalactica.Infrastructure.Graphql.Types.Result;

using BusinessLogic.Contracts;
using HotChocolate.Types;

public class DocumentStructureNodeOutput : ObjectType<DocumentStructureNodeResult>
{
    protected override void Configure(IObjectTypeDescriptor<DocumentStructureNodeResult> descriptor)
    {
        descriptor
            .Field(f => f.Id)
            .Description("Unique identifier of the entity")
            .Type<NonNullType<FloatType>>();
    }
}