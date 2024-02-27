using MediatR;
using TodoService.Domain.ReadModels;
using TodoService.Domain.RepositoryAbstractions.Read;
using TodoService.Domain.ResultPattern;

namespace TodoService.Application.Queries.Todo.GetTodo;

public sealed class GetTodoQueryHandler : IRequestHandler<GetTodoQuery, Result<TodoSummary>>
{
    private readonly ITodoSummaryRepository _todoSummaryRepository;

    public GetTodoQueryHandler(ITodoSummaryRepository todoSummaryRepository)
    {
        _todoSummaryRepository = todoSummaryRepository ?? throw new ArgumentNullException(nameof(todoSummaryRepository));
    }

    public async Task<Result<TodoSummary>> Handle(GetTodoQuery request, CancellationToken cancellationToken)
    {
        var todoResult = await _todoSummaryRepository.GetAsync(request.Id, cancellationToken);
        
        return todoResult is {IsSuccess: true, Value: not null } ?
            Result<TodoSummary>.Success(todoResult.Value) :
            Result<TodoSummary>.Failure(todoResult.Error);
    }
}