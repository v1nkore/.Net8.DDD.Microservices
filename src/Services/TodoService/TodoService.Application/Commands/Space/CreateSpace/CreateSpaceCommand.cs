using MediatR;
using TodoService.Application.Responses.Space;
using TodoService.Domain.ResultPattern;

namespace TodoService.Application.Commands.Space.CreateSpace;

public sealed record CreateSpaceCommand(
    string Name,
    string? Avatar) : IRequest<Result<SpaceResponse>>;