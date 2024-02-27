using Microsoft.EntityFrameworkCore;
using TodoService.Domain.Aggregates.TodoAggregate;
using TodoService.Domain.ReadModels;
using TodoService.Domain.RepositoryAbstractions.Write;
using TodoService.Domain.ResultPattern;
using TodoService.Domain.ResultPattern.Errors;
using TodoService.Infrastructure.Data;

namespace TodoService.Infrastructure.Repositories.Write;

public sealed class TodoRepository : ITodoRepository
{
    private readonly TodoWriteContext _writeContext;
    private readonly TodoReadContext _readContext;

    public TodoRepository(TodoWriteContext writeContext, TodoReadContext readContext)
    {
        _writeContext = writeContext ?? throw new ArgumentNullException(nameof(writeContext));
        _readContext = readContext ?? throw new ArgumentNullException(nameof(readContext));
    }

    public async Task<Result<Todo>> GetAsync(TodoId id, CancellationToken cancellationToken)
    {
        var todo = await _writeContext.Todo.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

        return todo is not null ? Result<Todo>.Success(todo) : Result<Todo>.Failure(TodoErrors.NotFound);
    }

    public async Task<Result<Todo>> CreateAsync(Todo todo, CancellationToken cancellationToken)
    {
        await _writeContext.Todo.AddAsync(todo, cancellationToken);

        await _writeContext.SaveChangesAsync(cancellationToken);

        return Result<Todo>.Success(todo);
    }

    public async Task<Result<Todo>> AddChildTodoAsync(TodoId parentId, Todo todo, CancellationToken cancellationToken)
    {
        var parentTodo = await _writeContext.Todo
            .Include(t => t.Children)
            .FirstOrDefaultAsync(t => t.Id == parentId, cancellationToken);
        if (parentTodo is null)
        {
            return Result<Todo>.Failure(TodoErrors.NotFound);
        }

        parentTodo.AddChildTodo(todo);

        await _readContext.TodoSummaries.AddAsync(todo.ToSummary(), cancellationToken);
        await _writeContext.SaveChangesAsync(cancellationToken);

        return Result<Todo>.Success(todo);
    }

    public async Task<Result<Todo>> UpdateAsync(Todo todo, CancellationToken cancellationToken)
    {
        _writeContext.Entry(todo).State = EntityState.Modified;
        await _writeContext.SaveChangesAsync(cancellationToken);

        return Result<Todo>.Success(todo);
    }

    public async Task<Result> DeleteAsync(TodoId id, CancellationToken cancellationToken)
    {
        if (await _writeContext.Todo.FirstOrDefaultAsync(t => t.Id == id, cancellationToken) is { } todo)
        {
            _writeContext.Todo.Remove(todo);
            await _writeContext.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

        return Result.Failure(TodoErrors.NotFound);
    }
}