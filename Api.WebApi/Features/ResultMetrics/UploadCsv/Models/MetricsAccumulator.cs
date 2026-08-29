namespace ResultMetrics.Api.WebApi.Features.ResultMetrics.UploadCsv.Models;

public class MetricsAccumulator
{
    private int count;
    private List<double> values = new();
    private double sumValues;
    private double minValue = Double.MaxValue;
    private double maxValue = Double.MinValue;
    private DateTime minDate = DateTime.MaxValue;
    private DateTime maxDate = DateTime.MinValue;
    private double sumExecutionTime;
    
    public void Add(ValueCsvRecord record)
    {
        var date = record.Date;
        
        count++;
        values.Add(record.Value);
        sumValues += record.Value;
        minValue = Math.Min(minValue, record.Value);
        maxValue = Math.Max(maxValue, record.Value);
        
        minDate = date < minDate ? date : minDate;
        maxDate = date > maxDate ? date : maxDate;
        
        sumExecutionTime += record.ExecutionTime;
    }

    public int Count => count;
    public double DeltaDateInSeconds => (maxDate - minDate).TotalSeconds;
    public DateTime MinDate => minDate;
    public double AvgExecutionTimeInSeconds => sumExecutionTime / count;
    public double AvgValue => sumValues / count;
    public double MedianValue => GetMedian();
    public double MinValue => minValue;
    public double MaxValue => maxValue;

    private double GetMedian()
    {
        values.Sort();
        var middle = values.Count / 2;

        return values.Count % 2 == 0
            ? (values[middle - 1] + values[middle]) / 2
            : values[middle];
    }
}