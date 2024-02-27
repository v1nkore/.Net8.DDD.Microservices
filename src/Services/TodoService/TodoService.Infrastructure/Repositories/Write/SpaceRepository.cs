using Microsoft.EntityFrameworkCore;
using TodoService.Domain.Aggregates.SpaceAggregate;
using TodoService.Domain.Aggregates.TodoAggregate;
using TodoService.Domain.ReadModels;
using TodoService.Domain.RepositoryAbstractions.Write;
using TodoService.Domain.ResultPattern;
using TodoService.Domain.ResultPattern.Errors;
using TodoService.Infrastructure.Data;

namespace TodoService.Infrastructure.Repositories.Write;

public sealed class SpaceRepository : ISpaceRepository
{
    private readonly TodoWriteContext _writeContext;
    private readonly TodoReadContext _readContext;

    public SpaceRepository(TodoWriteContext writeContext, TodoReadContext readContext)
    {
        _writeContext = writeContext ?? throw new ArgumentNullException(nameof(writeContext));
        _readContext = readContext ?? throw new ArgumentNullException(nameof(readContext));
    }

    public async Task<Result<Space>> GetAsync(SpaceId id, CancellationToken cancellationToken)
    {
        var space = await _writeContext.Spaces.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

        return space is not null ? Result<Space>.Success(space) : Result<Space>.Failure(SpaceErrors.NotFound);
    }

    public async Task<Result<Space>> CreateAsync(Space space, CancellationToken cancellationToken)
    {
        await _writeContext.Spaces.AddAsync(space, cancellationToken);
        await _readContext.SpaceSummaries.AddAsync(space.ToSummary(), cancellationToken);
        await _writeContext.SaveChangesAsync(cancellationToken);

        return Result<Space>.Success(space);
    }

    public async Task<Result> AddTodoAsync(SpaceId spaceId, Todo todo, CancellationToken cancellationToken)
    {
        var space = await _writeContext.Spaces
            .Include(s => s.Todo)
            .FirstOrDefaultAsync(s => s.Id == spaceId, cancellationToken);
        if (space is null)
        {
            return Result.Failure(SpaceErrors.NotFound);
        }

        space.AddTodo(todo);
        
        await _readContext.TodoSummaries.AddAsync(todo.ToSummary(), cancellationToken);
        await _writeContext.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result<Space>> UpdateAsync(Space space, CancellationToken cancellationToken)
    {
        _writeContext.Entry(space).State = EntityState.Modified;
        await _writeContext.SaveChangesAsync(cancellationToken);

        return Result<Space>.Success(space);
    }

    public async Task<Result> DeleteAsync(SpaceId id, CancellationToken cancellationToken)
    {
        if (await _writeContext.Spaces.FirstOrDefaultAsync(s => s.Id == id, cancellationToken) is { } space)
        {
            _writeContext.Spaces.Remove(space);
            await _writeContext.SaveChangesAsync(cancellationToken);
            
            return Result.Success();
        }
        
        return Result.Failure(SpaceErrors.NotFound);
    }
}