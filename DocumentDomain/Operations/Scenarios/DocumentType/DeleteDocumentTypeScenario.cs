namespace DocumentDomain.Operations.Scenarios.DocumentType;

using Commands.DocumentType;
using Common.Sagas;

/// <summary>
///     Deleting <see cref="DocumentType" /> scenario provides a single method api to delete a <see cref="DocumentType" />
///     entity from the system safely keeping up the integrity of the data.
/// </summary>
/// <param name="deleteDocumentTypeCommand"><see cref="IDeleteDocumentTypeCommand" /> implementation.</param>
public class DeleteDocumentTypeScenario(
    IDeleteDocumentTypeCommand deleteDocumentTypeCommand
) : IHaveInputSaga<DeleteDocumentTypeScenarioContext>
{
    /// <summary>
    ///     Executes the scenario.
    /// </summary>
    /// <param name="context">Context</param>
    /// <param name="cancellationToken">
    ///     <see cref="CancellationToken" />
    /// </param>
    public async Task ExecuteAsync(DeleteDocumentTypeScenarioContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await deleteDocumentTypeCommand.ExecuteAsync(
                context.Payload,
                cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}