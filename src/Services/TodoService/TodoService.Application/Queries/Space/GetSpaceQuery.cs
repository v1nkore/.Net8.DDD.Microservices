using MediatR;
using TodoService.Domain.Aggregates.SpaceAggregate;
using TodoService.Domain.ReadModels;
using TodoService.Domain.ResultPattern;

namespace TodoService.Application.Queries.Space;

public sealed record GetSpaceQuery(SpaceId Id) : IRequest<Result<SpaceSummary>>;