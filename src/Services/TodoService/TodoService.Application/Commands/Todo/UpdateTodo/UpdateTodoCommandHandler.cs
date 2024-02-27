using MediatR;
using TodoService.Application.HandmadeMappers;
using TodoService.Application.Responses.Todo;
using TodoService.Domain.RepositoryAbstractions.Write;
using TodoService.Domain.ResultPattern;

namespace TodoService.Application.Commands.Todo.UpdateTodo;

public sealed class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, Result<TodoResponse>>
{
    private readonly ITodoRepository _todoRepository;

    public UpdateTodoCommandHandler(ITodoRepository todoRepository)
    {    
        _todoRepository = todoRepository ?? throw new ArgumentNullException(nameof(todoRepository));
    }

    public async Task<Result<TodoResponse>> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var entity = request.ToEntity();
        var result = await _todoRepository.UpdateAsync(entity, cancellationToken);

        return Result<TodoResponse>.Failure(Error.None);
    }
}