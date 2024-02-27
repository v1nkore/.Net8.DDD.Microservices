using MediatR;
using TodoService.Domain.Aggregates.TodoAggregate;
using TodoService.Domain.ResultPattern;

namespace TodoService.Application.Commands.Todo.DeleteTodo;

public sealed record DeleteTodoCommand(TodoId Id) : IRequest<Result>;