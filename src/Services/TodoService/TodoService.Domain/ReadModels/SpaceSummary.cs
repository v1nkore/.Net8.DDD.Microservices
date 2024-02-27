namespace TodoService.Domain.ReadModels;

public sealed record SpaceSummary(
    Guid Id,
    string Name,
    string? Avatar);