using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoService.Domain.Aggregates.TodoAggregate;

namespace TodoService.Infrastructure.EntityConfigurations;

public sealed class TodoEntityConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.ToTable("todo");

        builder.HasKey(t => t.Id);

        builder
            .Property(t => t.Id)
            .HasConversion(
            todo => todo.Value,
            value => new TodoId(value));
        
        builder
            .Property(t => t.Name)
            .IsRequired();

        builder
            .HasOne(t => t.Parent)
            .WithMany(t => t.Children)
            .HasForeignKey(t => t.ParentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Navigation(t => t.Children)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.ComplexProperty(t => t.EisenhowerMatrix, subBuilder =>
        {
            subBuilder.IsRequired();
            subBuilder.Property(em => em.IsUrgent).HasColumnName("is_urgent");
            subBuilder.Property(em => em.IsImportant).HasColumnName("is_important");
        });
        
        builder.Ignore(s => s.DomainEvents);
    }
}