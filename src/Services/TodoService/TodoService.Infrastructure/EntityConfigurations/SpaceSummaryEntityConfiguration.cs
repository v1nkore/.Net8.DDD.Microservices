using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoService.Domain.ReadModels;

namespace TodoService.Infrastructure.EntityConfigurations;

public sealed class SpaceSummaryEntityConfiguration : IEntityTypeConfiguration<SpaceSummary>
{
    public void Configure(EntityTypeBuilder<SpaceSummary> builder)
    {
        builder.ToTable("table_summary");

        builder.HasKey(ss => ss.Id);
        
        builder.Property(ss => ss.Name).IsRequired();
    }
}