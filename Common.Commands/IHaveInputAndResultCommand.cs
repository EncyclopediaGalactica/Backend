namespace Common.Commands;

using LanguageExt;

public interface IHaveInputAndResultCommand<TInput, TOutput>
{
    Task<Option<TOutput>> ExecuteAsync(TInput? input, CancellationToken cancellationToken = default);
}