using System.Net;

namespace ResultMetrics.Common.Result;

public class Result<TValue> : Result
{
    private readonly TValue value;

    public Result(TValue value, HttpStatusCode statusCode, Fault? fault = null) : base(statusCode, fault)
    {
        this.value = value;
    }

    public TValue Value
    {
        get
        {
            EnsureSuccess();
            return value;
        }
    }

    public static Result<TValue> Success(TValue value, HttpStatusCode statusCode)
    {
        return new Result<TValue>(value, statusCode);
    }

    public static Result<TValue> Failure(Fault fault,  HttpStatusCode statusCode)
    {
        ArgumentNullException.ThrowIfNull(fault);

        return new Result<TValue>(default!, statusCode, fault);
    }
}