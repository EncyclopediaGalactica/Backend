namespace EncyclopediaGalactica.Core.Common;

public record ErrorResult(Guid CorrelationId, string ErrorMessage);
