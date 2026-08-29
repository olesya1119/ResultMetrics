namespace ResultMetrics.Common.Result;

public class FaultException: Exception
{
    public FaultException(Fault fault): base(fault.Message)
    {
        Fault = fault;
    }

    public Fault Fault { get; }
}