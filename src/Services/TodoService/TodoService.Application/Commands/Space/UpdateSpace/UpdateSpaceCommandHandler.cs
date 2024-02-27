using MediatR;
using TodoService.Application.HandmadeMappers;
using TodoService.Application.Responses.Space;
using TodoService.Domain.RepositoryAbstractions.Write;
using TodoService.Domain.ResultPattern;

namespace TodoService.Application.Commands.Space.UpdateSpace;

public sealed class UpdateSpaceCommandHandler : IRequestHandler<UpdateSpaceCommand, Result<SpaceResponse>>
{
    private readonly ISpaceRepository _spaceRepository;

    public UpdateSpaceCommandHandler(ISpaceRepository spaceRepository)
    {
        _spaceRepository = spaceRepository ?? throw new ArgumentNullException(nameof(spaceRepository));
    }

    public async Task<Result<SpaceResponse>> Handle(UpdateSpaceCommand request, CancellationToken cancellationToken)
    {
        var entity = request.ToEntity();
        var result = await _spaceRepository.UpdateAsync(entity, cancellationToken);

        return result is {IsSuccess: true, Value: not null } ?
            Result<SpaceResponse>.Success(result.Value.ToResponse()) :
            Result<SpaceResponse>.Failure(result.Error);
    }
}