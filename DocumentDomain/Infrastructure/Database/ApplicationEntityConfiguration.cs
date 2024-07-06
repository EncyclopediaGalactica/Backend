using DocumentDomain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocumentDomain.Infrastructure.Database;

public class ApplicationEntityConfiguration : IEntityTypeConfiguration<Application>
{
    public void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.ToTable("application");
        builder.HasKey(k => k.Id);
        builder.Property(k => k.Id).ValueGeneratedOnAdd();
        builder.Property(k => k.Id).HasColumnName("id");
        builder.Property(k => k.Name).HasColumnName("name");
        builder.Property(k => k.Description).HasColumnName("description");
    }
}