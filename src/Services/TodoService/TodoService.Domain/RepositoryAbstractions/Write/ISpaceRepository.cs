using TodoService.Domain.Aggregates.SpaceAggregate;
using TodoService.Domain.Aggregates.TodoAggregate;
using TodoService.Domain.ResultPattern;

namespace TodoService.Domain.RepositoryAbstractions.Write;

public interface ISpaceRepository
{
    Task<Result<Space>> GetAsync(SpaceId id, CancellationToken cancellationToken);

    Task<Result<Space>> CreateAsync(Space space, CancellationToken cancellationToken);

    Task<Result> AddTodoAsync(SpaceId spaceId, Todo todo, CancellationToken cancellationToken);

    Task<Result<Space>> UpdateAsync(Space space, CancellationToken cancellationToken);

    Task<Result> DeleteAsync(SpaceId id, CancellationToken cancellationToken);
}