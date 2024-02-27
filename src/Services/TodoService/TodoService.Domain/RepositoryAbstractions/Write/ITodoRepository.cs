using TodoService.Domain.Aggregates.TodoAggregate;
using TodoService.Domain.ResultPattern;

namespace TodoService.Domain.RepositoryAbstractions.Write;

public interface ITodoRepository
{
    Task<Result<Todo>> GetAsync(TodoId id, CancellationToken cancellationToken);

    Task<Result<Todo>> CreateAsync(Todo todo, CancellationToken cancellationToken);

    Task<Result<Todo>> AddChildTodoAsync(TodoId parentId, Todo todo, CancellationToken cancellationToken);

    Task<Result<Todo>> UpdateAsync(Todo todo, CancellationToken cancellationToken);

    Task<Result> DeleteAsync(TodoId id, CancellationToken cancellationToken);
}