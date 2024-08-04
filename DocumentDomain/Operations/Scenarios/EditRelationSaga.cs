namespace DocumentDomain.Operations.Scenarios;

using Commands;
using Common.Sagas;
using EncyclopediaGalactica.BusinessLogic.Contracts;
using LanguageExt;
using Microsoft.Extensions.Logging;

public class EditRelationSaga(
    IEditRelationCommand editRelationCommand,
    IGetRelationByIdCommand getRelationByIdCommand,
    ILogger<EditRelationSaga> logger) : IHaveInputAndResultSaga<RelationResult, EditRelationSagaContext>
{
    public async Task<Option<RelationResult>> ExecuteAsync(EditRelationSagaContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            return await EditRelationBusinessLogicAsync(context.Payload, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            string m = $"Error happened during execution of {nameof(EditRelationSaga)} saga.";
            throw new SagaException(m, e);
        }
    }

    private async Task<RelationResult> EditRelationBusinessLogicAsync(
        RelationInput contextPayload,
        CancellationToken cancellationToken)
    {
        await editRelationCommand.EditAsync(contextPayload, cancellationToken).ConfigureAwait(false);
        return await getRelationByIdCommand.GetByIdAsync(contextPayload.Id, cancellationToken).ConfigureAwait(false);
    }
}