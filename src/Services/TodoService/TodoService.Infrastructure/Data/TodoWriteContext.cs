using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoService.Domain.Aggregates.SpaceAggregate;
using TodoService.Domain.Aggregates.TodoAggregate;
using TodoService.Domain.Common;
using TodoService.Infrastructure.EntityConfigurations;

namespace TodoService.Infrastructure.Data;

public sealed class TodoWriteContext : DbContext
{
    private readonly IMediator _mediator;
    
    public TodoWriteContext(DbContextOptions<TodoWriteContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public DbSet<Todo> Todo { get; set; } = null!;

    public DbSet<Space> Spaces { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TodoEntityConfiguration());
        modelBuilder.ApplyConfiguration(new SpaceEntityConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var domainEvents =
            ChangeTracker.Entries<Entity>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Count != 0)
                .SelectMany(e => e.DomainEvents)
                .ToList();
        
        var result = await base.SaveChangesAsync(cancellationToken);
        
        foreach (var domainEvent in domainEvents)
        {
            await _mediator.Publish(domainEvent, cancellationToken);
        }
        
        return result;
    }
}