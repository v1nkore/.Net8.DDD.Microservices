namespace TodoService.Domain.ResultPattern;

public record Result
{
    private protected Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None ||
            !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
    }
    
    public bool IsSuccess { get; protected init; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; protected set; }

    public static Result Success() => new(true, Error.None);

    public static Result Failure(Error error) => new(false, error);
}

public sealed record Result<TValue> : Result where TValue : class?
{
    private Result(bool isSuccess, TValue? value, Error error) : base(isSuccess, error)
    {
        if (isSuccess && error != Error.None ||
            !isSuccess && error == Error.None ||
            isSuccess && value is null)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSuccess = isSuccess;
        Value = value;
        Error = error;
    }
    
    public TValue? Value { get; }

    public static Result<TValue> Success(TValue value) => new(true, value, Error.None);
    public new static Result<TValue> Failure(Error error) => new(false, null, error);
}

public sealed record Error(string Code, string Description)
{
    public static readonly Error None = new(string.Empty, string.Empty);
}
