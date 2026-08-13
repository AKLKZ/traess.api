namespace Traess.Domain.Common;

public class Result
{
    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public IReadOnlyList<Error> Errors { get; }

    protected Result(bool isSuccess, IReadOnlyList<Error> errors)
    {
        if (isSuccess && errors.Count > 0)
            throw new ArgumentException("A successful result cannot contain errors.", nameof(errors));

        if (!isSuccess && errors.Count == 0)
            throw new ArgumentException("A failed result must contain at least one error.", nameof(errors));

        IsSuccess = isSuccess;
        Errors = errors;
    }

    public static Result Success() => new(true, Array.Empty<Error>());

    public static Result Failure(Error error) => new(false, new[] { error });

    public static Result Failure(IEnumerable<Error> errors) => new(false, errors.ToArray());

    public Result<TNew> PropagateFail<TNew>()
    {
        if (IsSuccess)
            throw new InvalidOperationException("Cannot propagate failure from a successful result.");

        return Result<TNew>.Failure(Errors);
    }
}

public sealed class Result<T> : Result
{
    private readonly T? _data;

    public T Data => IsSuccess
        ? _data!
        : throw new InvalidOperationException("Cannot access Data on a failed result.");

    private Result(bool isSuccess, T? data, IReadOnlyList<Error> errors) : base(isSuccess, errors)
    {
        _data = data;
    }

    public static Result<T> Success(T data) => new(true, data, Array.Empty<Error>());

    public new static Result<T> Failure(Error error) => new(false, default, new[] { error });

    public new static Result<T> Failure(IEnumerable<Error> errors) => new(false, default, errors.ToArray());

    public new Result<TNew> PropagateFail<TNew>()
    {
        if (IsSuccess)
            throw new InvalidOperationException("Cannot propagate failure from a successful result.");

        return Result<TNew>.Failure(Errors);
    }

    public Result PropagateFail()
    {
        if (IsSuccess)
            throw new InvalidOperationException("Cannot propagate failure from a successful result.");

        return Result.Failure(Errors);
    }
}
