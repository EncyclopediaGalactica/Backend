using Common.Sagas;

namespace DocumentDomain.Operations.Sagas;

public class DeleteRelationSagaContext : ISagaContextWithPayload<long>
{
    public long Payload { get; set; }
}