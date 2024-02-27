using TodoService.Domain.Aggregates.SpaceAggregate;
using TodoService.Domain.Aggregates.TodoAggregate;

namespace TodoService.Domain.ReadModels;

public static class ReadModelsMapper
{
    public static TodoSummary ToSummary(this Todo todo)
    {
        var todoSummary = new TodoSummary(
            todo.Id.Value,
            todo.Name,
            todo.Description,
            todo.Deadline,
            todo.SpaceId?.Value,
            todo.ParentId?.Value);

        return todoSummary;
    }

    public static SpaceSummary ToSummary(this Space space)
    {
        var spaceSummary = new SpaceSummary(
            space.Id.Value,
            space.Name,
            space.Avatar);

        return spaceSummary;
    }
}