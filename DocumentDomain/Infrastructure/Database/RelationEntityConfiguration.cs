using DocumentDomain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocumentDomain.Infrastructure.Database;

public class RelationEntityConfiguration : IEntityTypeConfiguration<Relation>
{
    public void Configure(EntityTypeBuilder<Relation> builder)
    {
        builder.ToTable("relation");
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.LeftId).HasColumnName("left_end_id");
        builder.Property(p => p.RightId).HasColumnName("right_end_id");
    }
}