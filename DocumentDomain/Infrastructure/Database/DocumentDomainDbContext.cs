namespace EncyclopediaGalactica.DocumentDomain.Infrastructure.Database;

using Entity;
using Microsoft.EntityFrameworkCore;

public class DocumentDomainDbContext : DbContext
{
    protected DocumentDomainDbContext()
    {
    }

    public DocumentDomainDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Document> Documents => Set<Document>();
    public DbSet<DocumentStructureNode> DocumentStructureNodes => Set<DocumentStructureNode>();
    public DbSet<Relation> Relations => Set<Relation>();
    public DbSet<Application> Applications => Set<Application>();

    public DbSet<DocumentType> DocumentTypes => Set<DocumentType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DocumentConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DocumentStructureNodeConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RelationConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DocumentTypeConfiguration).Assembly);
    }
}