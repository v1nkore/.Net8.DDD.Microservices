using MediatR;
using TodoService.Application.HandmadeMappers;
using TodoService.Application.Responses.Todo;
using TodoService.Domain.RepositoryAbstractions.Write;
using TodoService.Domain.ResultPattern;

namespace TodoService.Application.Commands.Todo.CreateTodo;

public sealed class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, Result<TodoResponse>>
{
    private readonly ITodoRepository _todoRepository;

    public CreateTodoCommandHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository ?? throw new ArgumentNullException(nameof(todoRepository));
    }

    public async Task<Result<TodoResponse>> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = request.ToEntity();
        var result = await _todoRepository.CreateAsync(todo, cancellationToken);
        
        return result is {IsSuccess: true, Value: not null } ?
            Result<TodoResponse>.Success(result.Value.ToResponse()) :
            Result<TodoResponse>.Failure(result.Error);
    }
}