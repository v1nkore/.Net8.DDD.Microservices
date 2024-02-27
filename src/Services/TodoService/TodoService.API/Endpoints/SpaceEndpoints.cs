using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoService.Application.Commands.Space.AddTodo;
using TodoService.Application.Commands.Space.CreateSpace;
using TodoService.Application.Commands.Space.DeleteSpace;
using TodoService.Application.Commands.Space.UpdateSpace;
using TodoService.Application.Commands.Todo.CreateTodo;
using TodoService.Application.Queries.Space;
using TodoService.Domain.Aggregates.SpaceAggregate;
using TodoService.Domain.ResultPattern;

namespace TodoService.API.Endpoints;

public static class SpaceEndpoints
{
    public static void MapSpaceEndpoints(this WebApplication app)
    {
        var spaces = app.MapGroup("/spaces");
        
        spaces.MapGet("/{id}", async ([FromRoute] Guid id, IMediator mediator) =>
        {
            var query = new GetSpaceQuery(new SpaceId(id));
            var getSpaceResult = await mediator.Send(query);

            return getSpaceResult is { IsSuccess: true, Value: not null } ? 
                Results.Ok(getSpaceResult.Value) : 
                Results.NotFound(getSpaceResult.Error);
        });

        spaces.MapPost("/", async ([FromBody] CreateSpaceCommand command, IMediator mediator) =>
        {
            var createSpaceResult = await mediator.Send(command);

            return createSpaceResult is { IsSuccess: true, Value: not null }
                ? Results.Ok(createSpaceResult.Value)
                : Results.BadRequest(createSpaceResult.Error);
        });

        spaces.MapPost("/todo/{spaceId}", async (Guid spaceId, CreateTodoCommand command, IMediator mediator) =>
        {
            var addTodoToSpaceCommand = new AddTodoToSpaceCommand(new SpaceId(spaceId), command);
            var addTodoResult = await mediator.Send(addTodoToSpaceCommand);

            return addTodoResult.IsSuccess ? Results.NoContent() : Results.BadRequest(addTodoResult.Error);
        });
        
        spaces.MapPatch("/", async ([FromBody] UpdateSpaceCommand command, IMediator mediator) =>
        {
            var updateSpaceResult = await mediator.Send(command);

            return updateSpaceResult is { IsSuccess: true, Value: not null } ?
                Results.Ok(updateSpaceResult.Value) :
                Results.BadRequest(updateSpaceResult.Error);
        });

        spaces.MapDelete("/{id}", async ([FromRoute] Guid id, IMediator mediator) =>
        {
            var deleteSpaceCommand = new DeleteSpaceCommand(new SpaceId(id));
            var deleteSpaceResult = await mediator.Send(deleteSpaceCommand);

            return deleteSpaceResult.IsSuccess ?
                Results.NoContent() :
                Results.NotFound(deleteSpaceResult.Error);
        });
    }
}