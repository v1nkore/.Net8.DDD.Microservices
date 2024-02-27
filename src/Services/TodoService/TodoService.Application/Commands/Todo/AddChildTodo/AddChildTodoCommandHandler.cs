using MediatR;
using TodoService.Application.HandmadeMappers;
using TodoService.Application.Responses.Todo;
using TodoService.Domain.RepositoryAbstractions.Write;
using TodoService.Domain.ResultPattern;

namespace TodoService.Application.Commands.Todo.AddChildTodo;

public sealed class AddChildTodoCommandHandler : IRequestHandler<AddChildTodoCommand, Result<TodoResponse>>
{
    private readonly ITodoRepository _todoRepository;

    public AddChildTodoCommandHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<Result<TodoResponse>> Handle(AddChildTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = request.CreateTodoCommand.ToEntity();
        var result = await _todoRepository.AddChildTodoAsync(request.ParentId, todo, cancellationToken);

        return result is {IsSuccess: true, Value: not null } ?
            Result<TodoResponse>.Success(result.Value.ToResponse()) :
            Result<TodoResponse>.Failure(result.Error);
    }
}