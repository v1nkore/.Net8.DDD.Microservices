using MediatR;
using TodoService.Domain.RepositoryAbstractions.Write;
using TodoService.Domain.ResultPattern;

namespace TodoService.Application.Commands.Space.DeleteSpace;

public sealed class DeleteSpaceCommandHandler : IRequestHandler<DeleteSpaceCommand, Result>
{
    private readonly ISpaceRepository _spaceRepository;

    public DeleteSpaceCommandHandler(ISpaceRepository spaceRepository)
    {
        _spaceRepository = spaceRepository ?? throw new ArgumentNullException(nameof(spaceRepository));
    }

    public async Task<Result> Handle(DeleteSpaceCommand request, CancellationToken cancellationToken)
    {
        return await _spaceRepository.DeleteAsync(request.Id, cancellationToken);
    }
}