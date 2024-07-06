#region

using Common.Sagas;
using DocumentDomain.Contracts;

#endregion

namespace DocumentDomain.Operations.Sagas;

public class EditRelationSagaContext : ISagaContextWithPayload<RelationInput>
{
    public RelationInput Payload { get; set; }
}