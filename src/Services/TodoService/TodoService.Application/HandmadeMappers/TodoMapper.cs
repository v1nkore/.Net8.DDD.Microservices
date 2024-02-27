using TodoService.Application.Commands.Todo.CreateTodo;
using TodoService.Application.Commands.Todo.UpdateTodo;
using TodoService.Application.Responses.Todo;
using TodoService.Domain.Aggregates.TodoAggregate;

namespace TodoService.Application.HandmadeMappers;

public static class TodoMapper
{
    public static TodoResponse ToResponse(this Todo todo)
    {
        var response = new TodoResponse(
            todo.Id,
            todo.Name,
            todo.Description,
            todo.Deadline,
            todo.SpaceId,
            todo.ParentId);
        
        return response;
    }

    public static Todo ToEntity(this CreateTodoCommand command)
    {
        var entity = Todo.Create(
            new TodoId(Guid.Empty),
            command.Name,
            command.Description,
            command.Deadline,
            command.EisenhowerMatrix,
            command.SpaceId);

        return entity;
    }

    public static Todo ToEntity(this UpdateTodoCommand command)
    {
        var entity = Todo.Create(
            command.Id,
            command.Name,
            command.Description,
            command.Deadline,
            command.EisenhowerMatrix,
            command.SpaceId);

        return entity;
    }
}