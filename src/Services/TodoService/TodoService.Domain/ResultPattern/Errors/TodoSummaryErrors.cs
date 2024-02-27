namespace TodoService.Domain.ResultPattern.Errors;

public static class TodoSummaryErrors
{
    public static readonly Error NotFound = new Error(
        "TodoSummary.NotFound", "Todo summary was not found");
}