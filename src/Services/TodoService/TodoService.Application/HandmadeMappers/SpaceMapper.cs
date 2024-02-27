using TodoService.Application.Commands.Space.CreateSpace;
using TodoService.Application.Commands.Space.UpdateSpace;
using TodoService.Application.Responses.Space;
using TodoService.Domain.Aggregates.SpaceAggregate;

namespace TodoService.Application.HandmadeMappers;

public static class SpaceMapper
{
    public static SpaceResponse ToResponse(this Space space)
    {
        var response = new SpaceResponse(
            space.Id,
            space.Name,
            space.Avatar);

        return response;
    }

    public static Space ToEntity(this CreateSpaceCommand command)
    {
        var entity = Space.Create(
            new SpaceId(Guid.Empty),
            command.Name,
            command.Avatar);

        return entity;
    }

    public static Space ToEntity(this UpdateSpaceCommand command)
    {
        var entity = Space.Create(
            command.Id,
            command.Name,
            command.Avatar);

        return entity;
    }
}