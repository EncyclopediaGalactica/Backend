namespace Common.Commands;

public interface IHaveInputAndResultCommand<TInput, TOutput>
{
    Task<TOutput> ExecuteAsync(TInput? input, CancellationToken cancellationToken = default);
}