using MediatR;
using TodoService.Application.HandmadeMappers;
using TodoService.Application.Responses.Space;
using TodoService.Domain.RepositoryAbstractions.Write;
using TodoService.Domain.ResultPattern;

namespace TodoService.Application.Commands.Space.CreateSpace;

public sealed class CreateSpaceCommandHandler : IRequestHandler<CreateSpaceCommand, Result<SpaceResponse>>
{
    private readonly ISpaceRepository _spaceRepository;

    public CreateSpaceCommandHandler(ISpaceRepository spaceRepository)
    {
        _spaceRepository = spaceRepository ?? throw new ArgumentNullException(nameof(spaceRepository));
    }

    public async Task<Result<SpaceResponse>> Handle(CreateSpaceCommand request, CancellationToken cancellationToken)
    {
        var entity = request.ToEntity();
        var result = await _spaceRepository.CreateAsync(entity, cancellationToken);

        return result is {IsSuccess: true, Value: not null } ?
            Result<SpaceResponse>.Success(result.Value.ToResponse()) :
            Result<SpaceResponse>.Failure(result.Error);
    }
}