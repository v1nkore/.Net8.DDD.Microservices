using TodoService.Domain.Aggregates.TodoAggregate;
using TodoService.Domain.ReadModels;
using TodoService.Domain.ResultPattern;

namespace TodoService.Domain.RepositoryAbstractions.Read;

public interface ITodoSummaryRepository
{
    Task<Result<TodoSummary>> GetAsync(TodoId id, CancellationToken cancellationToken);
}