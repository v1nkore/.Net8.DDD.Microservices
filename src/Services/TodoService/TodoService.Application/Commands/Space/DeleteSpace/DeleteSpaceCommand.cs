using MediatR;
using TodoService.Domain.Aggregates.SpaceAggregate;
using TodoService.Domain.ResultPattern;

namespace TodoService.Application.Commands.Space.DeleteSpace;

public record DeleteSpaceCommand(SpaceId Id) : IRequest<Result>;