using MediatR;
using TodoService.Domain.Aggregates.TodoAggregate;
using TodoService.Domain.ReadModels;
using TodoService.Domain.ResultPattern;

namespace TodoService.Application.Queries.Todo.GetTodo;

public record GetTodoQuery(TodoId Id) : IRequest<Result<TodoSummary>>;