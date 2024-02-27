using TodoService.Domain.Aggregates.SpaceAggregate;
using TodoService.Domain.ReadModels;
using TodoService.Domain.ResultPattern;

namespace TodoService.Domain.RepositoryAbstractions.Read;

public interface ISpaceSummaryRepository
{
    Task<Result<SpaceSummary>> GetAsync(SpaceId id, CancellationToken cancellationToken);
}