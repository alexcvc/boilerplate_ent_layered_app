namespace Tool.Core.Abstractions;

public sealed record Result(bool IsSuccess, string? Error = null)
{
    public static Result Ok() => new(true);
    public static Result Fail(string error) => new(false, error);
}
