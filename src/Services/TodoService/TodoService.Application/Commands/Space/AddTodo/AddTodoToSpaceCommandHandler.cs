using MediatR;
using TodoService.Application.HandmadeMappers;
using TodoService.Application.Responses.Space;
using TodoService.Domain.RepositoryAbstractions.Write;
using TodoService.Domain.ResultPattern;

namespace TodoService.Application.Commands.Space.AddTodo;

public sealed class AddTodoToSpaceCommandHandler : IRequestHandler<AddTodoToSpaceCommand, Result>
{
    private readonly ISpaceRepository _spaceRepository;

    public AddTodoToSpaceCommandHandler(ISpaceRepository spaceRepository)
    {
        _spaceRepository = spaceRepository;
    }

    public async Task<Result> Handle(AddTodoToSpaceCommand request, CancellationToken cancellationToken)
    {
        var todo = request.Command.ToEntity();
        
        return await _spaceRepository.AddTodoAsync(request.SpaceId, todo, cancellationToken);
    }
}