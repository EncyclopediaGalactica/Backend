namespace EncyclopediaGalactica.Backend.ApplicationDomain.Entities;

public class Application
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}