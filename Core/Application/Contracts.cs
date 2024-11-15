namespace EncyclopediaGalactica.Core.Application;

public class ApplicationInput
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class ApplicationResult
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public static class ApplicationInputMapperExtensions
{
    public static Application ToApplication(this ApplicationInput applicationInput) =>
        new()
        {
            Id          = applicationInput.Id,
            Name        = applicationInput.Name,
            Description = applicationInput.Description,
        };

    public static ApplicationResult ToApplicationResult(this Application application) =>
        new()
        {
            Id          = application.Id,
            Name        = application.Name,
            Description = application.Description,
        };
}