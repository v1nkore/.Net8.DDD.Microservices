using MediatR;
using TodoService.Application.Responses.Todo;
using TodoService.Domain.Aggregates.SpaceAggregate;
using TodoService.Domain.Aggregates.TodoAggregate.ValueObjects;
using TodoService.Domain.ResultPattern;

namespace TodoService.Application.Commands.Todo.CreateTodo;

public sealed record CreateTodoCommand(
    string Name,
    string? Description,
    DateTime? Deadline,
    EisenhowerMatrix EisenhowerMatrix,
    SpaceId? SpaceId) : IRequest<Result<TodoResponse>>;
    