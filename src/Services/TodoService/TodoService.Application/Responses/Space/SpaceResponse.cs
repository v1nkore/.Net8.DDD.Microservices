using TodoService.Domain.Aggregates.SpaceAggregate;

namespace TodoService.Application.Responses.Space;

public sealed record SpaceResponse(
    SpaceId Id,
    string Name,
    string? Avatar);