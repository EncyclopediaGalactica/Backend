using EncyclopediaGalactica.BusinessLogic.Contracts;
using EncyclopediaGalactica.Infrastructure.Graphql.Resolvers.QueryResolvers;
using EncyclopediaGalactica.Infrastructure.Graphql.Types.Result;
using HotChocolate.Types;

namespace EncyclopediaGalactica.Infrastructure.Graphql.Types.Queries.Application;

public class GetAllApplications : ObjectTypeExtension<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor
            .Field("getAllApplications")
            .Description($"Returns all {nameof(BusinessLogic.Entities.Application)} entities of the system.")
            .Type<NonNullType<ListType<ApplicationOutput>>>()
            .ResolveWith<ApplicationQueryResolvers>(res => res.GetAllAsync(default, default, default));
    }
}