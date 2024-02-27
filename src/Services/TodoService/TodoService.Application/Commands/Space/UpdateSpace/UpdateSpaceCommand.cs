using MediatR;
using TodoService.Application.Responses.Space;
using TodoService.Domain.Aggregates.SpaceAggregate;
using TodoService.Domain.ResultPattern;

namespace TodoService.Application.Commands.Space.UpdateSpace;

public record UpdateSpaceCommand(
    SpaceId Id,
    string Name,
    string? Avatar) : IRequest<Result<SpaceResponse>>;