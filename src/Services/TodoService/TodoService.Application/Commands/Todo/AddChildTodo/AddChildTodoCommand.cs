using MediatR;
using TodoService.Application.Commands.Todo.CreateTodo;
using TodoService.Application.Responses.Todo;
using TodoService.Domain.Aggregates.TodoAggregate;
using TodoService.Domain.ResultPattern;

namespace TodoService.Application.Commands.Todo.AddChildTodo;

public sealed record AddChildTodoCommand(TodoId ParentId, CreateTodoCommand CreateTodoCommand) : IRequest<Result<TodoResponse>>;