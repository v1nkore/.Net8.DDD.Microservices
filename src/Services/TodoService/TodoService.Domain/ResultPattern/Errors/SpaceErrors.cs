namespace TodoService.Domain.ResultPattern.Errors;

public static class SpaceErrors
{
    public static readonly Error NotFound = new Error(
        "Space.NotFound", "Space was not found");
}