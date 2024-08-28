namespace DocumentDomain.Operations.Scenarios.Application;

using Commands.Application;
using EncyclopediaGalactica.BusinessLogic.Contracts;
using LanguageExt;

public class UpdateApplicationScenario(IUpdateApplicationCommand updateApplicationCommand)
{
    public async Task<Option<ApplicationResult>> ExecuteAsync(
        UpdateApplicationScenarioContext context,
        CancellationToken cancellationToken = default)
    {
        return await updateApplicationCommand.ExecuteAsync(context, cancellationToken).ConfigureAwait(false);
    }
}