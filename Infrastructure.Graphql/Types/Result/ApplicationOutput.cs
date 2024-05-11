using EncyclopediaGalactica.BusinessLogic.Contracts;
using HotChocolate.Types;

namespace EncyclopediaGalactica.Infrastructure.Graphql.Types.Result;

public class ApplicationOutput : ObjectType<ApplicationResult>
{
    protected override void Configure(IObjectTypeDescriptor<ApplicationResult> descriptor)
    {
        descriptor
            .Field(f => f.Id)
            .Description("Unique identifier of the entity")
            .Type<NonNullType<FloatType>>();

        descriptor
            .Field(f => f.Name)
            .Description("Name of the entity")
            .Type<NonNullType<StringType>>();

        descriptor
            .Field(f => f.Description)
            .Description("Description of the entity")
            .Type<NonNullType<StringType>>();
    }
}