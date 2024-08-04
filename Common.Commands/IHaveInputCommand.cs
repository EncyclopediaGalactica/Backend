namespace Common.Commands;

public interface IHaveInputCommand<TInput>
{
    Task ExecuteAsync(TInput? input, CancellationToken cancellationToken = default);
}