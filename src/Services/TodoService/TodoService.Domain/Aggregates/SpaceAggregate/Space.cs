using TodoService.Domain.Aggregates.TodoAggregate;
using TodoService.Domain.Common;

namespace TodoService.Domain.Aggregates.SpaceAggregate;

public sealed class Space : Entity, IAggregateRoot
{
    private Space(SpaceId id, string name, string? avatar)
    {
        Id = id;
        Name = name;
        Avatar = avatar;
    }

    public static Space Create(SpaceId id, string name, string? avatar)
    {
        var spaceIdValue = id.Value == Guid.Empty ? Guid.NewGuid() : id.Value;
        var spaceId = new SpaceId(spaceIdValue);
        var space = new Space(spaceId, name, avatar);
        
        return space;
    }

    private readonly List<Todo> _todo = [];
    
    public SpaceId Id { get; private set; }
    public string Name { get; private set; }
    public string? Avatar { get; private set; }
    
    public IReadOnlyCollection<Todo> Todo => _todo;

    public void AddTodo(Todo todo) => _todo.Add(todo);
}

public sealed record SpaceId(Guid Value);