using MediatR;
using TodoService.Domain.ReadModels;
using TodoService.Domain.RepositoryAbstractions.Read;
using TodoService.Domain.ResultPattern;

namespace TodoService.Application.Queries.Space;

public sealed class GetSpaceQueryHandler : IRequestHandler<GetSpaceQuery, Result<SpaceSummary>>
{
    private readonly ISpaceSummaryRepository _spaceSummaryRepository;

    public GetSpaceQueryHandler(ISpaceSummaryRepository spaceSummaryRepository)
    {
        _spaceSummaryRepository = spaceSummaryRepository ?? throw new ArgumentNullException(nameof(spaceSummaryRepository));
    }

    public async Task<Result<SpaceSummary>> Handle(GetSpaceQuery request, CancellationToken cancellationToken)
    {
        var result = await _spaceSummaryRepository.GetAsync(request.Id, cancellationToken);

        return result is {IsSuccess: true, Value: not null } ?
            Result<SpaceSummary>.Success(result.Value) :
            Result<SpaceSummary>.Failure(result.Error);
    }
}