
namespace Application.Interfaces;

public class Result<T>
{
    public bool Success { get; init; }
    public T? Data { get; init; }
    public string? Error { get; init; }
    public int? StatusCode { get; init; }

    public static Result<T> Ok(T data) =>
        new() { Success = true, Data = data };

    public static Result<T> Created(T data) =>
        new() { Success = true, Data = data, StatusCode = 201 };

    public static Result<T> NoContent() =>
        new() { Success = true, StatusCode = 204 };

    public static Result<T> Fail(string error, int statusCode) =>
        new() { Success = false, Error = error, StatusCode = statusCode };
}


public class Result : Result<object?>
{
    public static Result Ok() => new() { Success = true };
    public static Result Created() => new() { Success = true, StatusCode = 201 };
    public static new Result NoContent() => new() { Success = true, StatusCode = 204 };
    public static new Result Fail(string error, int statusCode) =>
        new() { Success = false, Error = error, StatusCode = statusCode };
}

