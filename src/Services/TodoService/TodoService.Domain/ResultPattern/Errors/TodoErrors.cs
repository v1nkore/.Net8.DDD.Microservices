namespace TodoService.Domain.ResultPattern.Errors;

public static class TodoErrors
{
    public static readonly Error NotFound = new Error(
        "Todo.NotFound", "Todo was not found");
}