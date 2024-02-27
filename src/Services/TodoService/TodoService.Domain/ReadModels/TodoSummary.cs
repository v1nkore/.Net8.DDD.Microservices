namespace TodoService.Domain.ReadModels;

public sealed record TodoSummary(
    Guid Id,
    string Name,
    string? Description,
    DateTime? Deadline,
    Guid? SpaceId,
    Guid? ParentId);