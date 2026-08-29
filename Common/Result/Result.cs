using System.Net;

namespace ResultMetrics.Common.Result;

public class Result
{
    protected Result(HttpStatusCode statusCode, Fault? fault)
    {
        Fault = fault;
        StatusCode = statusCode;
    }

    public Fault? Fault { get; }
    
    public HttpStatusCode StatusCode { get; }
    public bool Successful => this.Fault == null;
    
    
    public static Result Success(HttpStatusCode statusCode)
    {
        return new Result(statusCode, null);
    }

    public static Result Failure(Fault fault, HttpStatusCode statusCode)
    {
        ArgumentNullException.ThrowIfNull(fault);

        return new Result(statusCode, fault);
    }

    public void EnsureSuccess()
    {
        if (!Successful)
        {
            throw new FaultException(Fault!);
        }
    }
}

