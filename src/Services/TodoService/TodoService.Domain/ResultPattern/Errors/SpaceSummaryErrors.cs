namespace TodoService.Domain.ResultPattern.Errors;

public static class SpaceSummaryErrors
{
    public static readonly Error NotFound = new Error(
        "SpaceSummary.NotFound", "Space summary was not found");
}