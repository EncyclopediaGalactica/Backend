namespace EncyclopediaGalactica.Core.Common.Commands;

using LanguageExt;

public interface IHaveInputAndResultCommand<TInput, TOutput>
{
    Task<Option<TOutput>> ExecuteAsync(TInput ctx, CancellationToken cancellationToken = default);
}