#region

using DocumentDomain.Entity;
using Microsoft.EntityFrameworkCore;

#endregion

namespace DocumentDomain.Infrastructure.Database;

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


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DocumentEntityConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DocumentStructureNodeEntityConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RelationEntityConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationEntityConfiguration).Assembly);
    }
}