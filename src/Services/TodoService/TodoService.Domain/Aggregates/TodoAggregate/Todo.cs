using TodoService.Domain.Aggregates.SpaceAggregate;
using TodoService.Domain.Aggregates.TodoAggregate.ValueObjects;
using TodoService.Domain.Common;

namespace TodoService.Domain.Aggregates.TodoAggregate;

public sealed class Todo : Entity
{
    private Todo() {}
    
    private Todo(TodoId id, string name, string? description, DateTime? deadline, EisenhowerMatrix eisenhowerMatrix, SpaceId? spaceId, TodoId? parentId)
    {
        Id = id;
        Name = name;
        Description = description;
        Deadline = deadline;
        EisenhowerMatrix = eisenhowerMatrix;
        SpaceId = spaceId;
        ParentId = parentId;
    }
    
    public static Todo Create(
        TodoId id,
        string name,
        string? description,
        DateTime? deadline,
        EisenhowerMatrix eisenhowerMatrix,
        SpaceId? spaceId,
        TodoId? parentId = null)
    {
        var todoIdValue = id.Value == Guid.Empty ? Guid.NewGuid() : id.Value;
        var todoId = new TodoId(todoIdValue);
        var todo = new Todo(todoId, name, description, deadline, eisenhowerMatrix, spaceId, parentId);

        return todo;
    }

    public TodoId Id { get; private set; } = null!;
    public string Name { get; private set; } = null!;
    public string? Description { get; private set; }
    public DateTime? Deadline { get; private set; }

    public SpaceId? SpaceId { get; private set; }

    public TodoId? ParentId { get; private set; }
    public Todo? Parent { get; private set; }

    public EisenhowerMatrix EisenhowerMatrix { get; private set; } = null!;

    private readonly List<Todo> _children = [];
    public IReadOnlyCollection<Todo> Children => _children;

    public void AddChildTodo(Todo todo)
    {
        _children.Add(todo);
        todo.ParentId = Id;
    }
}

public sealed record TodoId(Guid Value);