namespace EncyclopediaGalactica.Core.Common;

/// <summary>
///     The error response object which will be sent back to the client by the controller if any error occurs during
///     processing the request.
///     The provided CorrelationId helps to see the operations the single request executed.
/// </summary>
/// <param name="Code">Representing the http error code.</param>
/// <param name="Message">The error message.</param>
/// <param name="CorrelationId">The correlation id.</param>
public record ErrorHttpResponse(int Code, string? Message, string CorrelationId);
