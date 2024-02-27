using TodoService.Domain.Aggregates.SpaceAggregate;
using TodoService.Domain.Aggregates.TodoAggregate;

namespace TodoService.Application.Responses.Todo;

public sealed record TodoResponse(
    TodoId Id,
    string Name,
    string? Description,
    DateTime? Deadline,
    SpaceId? SpaceId,
    TodoId? ParentId);