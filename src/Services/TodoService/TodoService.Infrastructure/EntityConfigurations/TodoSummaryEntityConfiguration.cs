using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoService.Domain.ReadModels;

namespace TodoService.Infrastructure.EntityConfigurations;

public sealed class TodoSummaryEntityConfiguration : IEntityTypeConfiguration<TodoSummary>
{
    public void Configure(EntityTypeBuilder<TodoSummary> builder)
    {
        builder.ToTable("todo_summary");

        builder.HasKey(ts => ts.Id);

        builder.Property(ts => ts.Name).IsRequired();
    }
}