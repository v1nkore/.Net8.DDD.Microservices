using Microsoft.EntityFrameworkCore;
using TodoService.Domain.Aggregates.TodoAggregate;
using TodoService.Domain.ReadModels;
using TodoService.Domain.RepositoryAbstractions.Read;
using TodoService.Domain.ResultPattern;
using TodoService.Domain.ResultPattern.Errors;
using TodoService.Infrastructure.Data;

namespace TodoService.Infrastructure.Repositories.Read;

public sealed class TodoSummaryRepository : ITodoSummaryRepository
{
    private readonly TodoReadContext _readContext;

    public TodoSummaryRepository(TodoReadContext readContext)
    {
        _readContext = readContext ?? throw new ArgumentNullException(nameof(readContext));
    }

    public async Task<Result<TodoSummary>> GetAsync(TodoId id, CancellationToken cancellationToken)
    {
        var todo = await _readContext.TodoSummaries.FirstOrDefaultAsync(t => t.Id == id.Value, cancellationToken);

        return todo is not null
            ? Result<TodoSummary>.Success(todo)
            : Result<TodoSummary>.Failure(TodoSummaryErrors.NotFound);
    }
}