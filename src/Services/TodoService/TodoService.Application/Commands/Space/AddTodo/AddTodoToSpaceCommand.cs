using MediatR;
using TodoService.Application.Commands.Todo.CreateTodo;
using TodoService.Application.Responses.Space;
using TodoService.Domain.Aggregates.SpaceAggregate;
using TodoService.Domain.ResultPattern;

namespace TodoService.Application.Commands.Space.AddTodo;

public sealed record AddTodoToSpaceCommand(SpaceId SpaceId, CreateTodoCommand Command) : IRequest<Result>;