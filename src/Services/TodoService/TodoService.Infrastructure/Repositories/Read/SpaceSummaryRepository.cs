using Microsoft.EntityFrameworkCore;
using TodoService.Domain.Aggregates.SpaceAggregate;
using TodoService.Domain.ReadModels;
using TodoService.Domain.RepositoryAbstractions.Read;
using TodoService.Domain.ResultPattern;
using TodoService.Domain.ResultPattern.Errors;
using TodoService.Infrastructure.Data;

namespace TodoService.Infrastructure.Repositories.Read;

public sealed class SpaceSummaryRepository : ISpaceSummaryRepository
{
    private readonly TodoReadContext _readContext;

    public SpaceSummaryRepository(TodoReadContext readContext)
    {
        _readContext = readContext ?? throw new ArgumentNullException(nameof(readContext));
    }

    public async Task<Result<SpaceSummary>> GetAsync(SpaceId id, CancellationToken cancellationToken)
    {
        var spaceSummary = await _readContext.SpaceSummaries.FirstOrDefaultAsync(s => s.Id == id.Value, cancellationToken);

        return spaceSummary is not null
            ? Result<SpaceSummary>.Success(spaceSummary) 
            : Result<SpaceSummary>.Failure(SpaceSummaryErrors.NotFound);
    }
}