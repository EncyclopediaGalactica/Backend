namespace Common.Commands;

using LanguageExt;

public interface IHaveResultCommand<TResult>
{
    Task<Option<TResult>> ExecuteAsync(CancellationToken cancellationToken);
}