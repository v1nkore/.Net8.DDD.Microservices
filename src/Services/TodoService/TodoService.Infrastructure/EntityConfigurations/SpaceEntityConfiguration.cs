using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoService.Domain.Aggregates.SpaceAggregate;

namespace TodoService.Infrastructure.EntityConfigurations;

public sealed class SpaceEntityConfiguration : IEntityTypeConfiguration<Space>
{
    public void Configure(EntityTypeBuilder<Space> builder)
    {
        builder.ToTable("space");

        builder.HasKey(s => s.Id);

        builder
            .Property(s => s.Id)
            .HasConversion(
                space => space.Value,
                value => new SpaceId(value));

        builder
            .Property(s => s.Name)
            .IsRequired();

        builder
            .HasMany(s => s.Todo)
            .WithOne()
            .HasForeignKey(s => s.SpaceId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Navigation(s => s.Todo)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.Ignore(s => s.DomainEvents);
    }
}