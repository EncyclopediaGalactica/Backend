#region

#endregion

namespace DocumentDomain.Operations.Sagas;

using Common.Sagas;
using Contracts;

public class EditRelationSagaContext : ISagaContextWithPayload<RelationInput>
{
    public RelationInput Payload { get; set; }
}