using Microsoft.EntityFrameworkCore;
using TodoService.Domain.ReadModels;
using TodoService.Infrastructure.EntityConfigurations;

namespace TodoService.Infrastructure.Data;

public sealed class TodoReadContext : DbContext
{
    public TodoReadContext(DbContextOptions<TodoReadContext> options) : base(options)
    {
    }

    public DbSet<TodoSummary> TodoSummaries { get; set; } = null!;
    
    public DbSet<SpaceSummary> SpaceSummaries { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TodoSummaryEntityConfiguration());
        modelBuilder.ApplyConfiguration(new SpaceSummaryEntityConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}