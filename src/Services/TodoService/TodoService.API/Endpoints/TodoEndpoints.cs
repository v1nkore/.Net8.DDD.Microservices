using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoService.Application.Commands.Todo.AddChildTodo;
using TodoService.Application.Commands.Todo.CreateTodo;
using TodoService.Application.Commands.Todo.DeleteTodo;
using TodoService.Application.Commands.Todo.UpdateTodo;
using TodoService.Application.Queries.Todo.GetTodo;
using TodoService.Domain.Aggregates.TodoAggregate;

namespace TodoService.API.Endpoints;

public static class TodoEndpoints
{
    public static void MapTodoEndpoints(this WebApplication app)
    {
        var todo = app.MapGroup("/todo");

        todo.MapGet("/{id}", async ([FromRoute] Guid id, IMediator mediator) =>
        {
            var query = new GetTodoQuery(new TodoId(id));
            var getTodoResult = await mediator.Send(query);

            return getTodoResult.IsSuccess 
                ? Results.Ok(getTodoResult.Value)
                : Results.NotFound(getTodoResult.Error);
        });
        
        todo.MapPost("/", async ([FromBody] CreateTodoCommand command, IMediator mediator) =>
        {
            var createTodoResult = await mediator.Send(command);

            return createTodoResult.IsSuccess ? 
                Results.Ok(createTodoResult.Value) :
                Results.BadRequest(createTodoResult.Error);
        });

        todo.MapPost("/{parentId}/child", async ([FromRoute] Guid parentId, [FromBody] CreateTodoCommand command, IMediator mediator) =>
        {
            var addChildTodoCommand = new AddChildTodoCommand(new TodoId(parentId), command);
            var addChildTodoResult = await mediator.Send(addChildTodoCommand);

            return addChildTodoResult.IsSuccess ? 
                Results.Ok(addChildTodoResult.Value) :
                Results.BadRequest(addChildTodoResult.Error);
        });
        
        todo.MapPatch("/", async ([FromBody] UpdateTodoCommand command, IMediator mediator) =>
        {
            var updateTodoResult = await mediator.Send(command);

            return updateTodoResult.IsSuccess ?
                Results.Ok(updateTodoResult.Value) :
                Results.BadRequest(updateTodoResult.Error);
        });
        
        todo.MapDelete("/{id}", async ([FromRoute] Guid id, IMediator mediator) =>
        {
            var deleteTodoCommand = new DeleteTodoCommand(new TodoId(id));
            var deleteTodoResult = await mediator.Send(deleteTodoCommand);

            return deleteTodoResult.IsSuccess ? 
                Results.NoContent() :
                Results.NotFound(deleteTodoResult.Error);
        });
    }
}