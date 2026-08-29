namespace ResultMetrics.Api.WebApi.Models;

public class MetricsResult
{
    /// <summary>
    /// Имя обработанного CSV-файла.
    /// </summary>
    public string FileName { get; set; } = null!;

    /// <summary>
    /// Дельта между максимальной и минимальной датой запуска операций в секундах.
    /// </summary>
    public double DeltaDateInSeconds { get; set; }

    /// <summary>
    /// Дата и время запуска первой операции.
    /// </summary>
    public DateTime MinDate { get; set; }

    /// <summary>
    /// Среднее время выполнения операций в секундах.
    /// </summary>
    public double AvgExecutionTimeInSeconds { get; set; }

    /// <summary>
    /// Среднее значение показателя.
    /// </summary>
    public double AvgValue { get; set; }

    /// <summary>
    /// Медианное значение показателя.
    /// </summary>
    public double MedianValue { get; set; }

    /// <summary>
    /// Минимальное значение показателя.
    /// </summary>
    public double MinValue { get; set; }

    /// <summary>
    /// Максимальное значение показателя.
    /// </summary>
    public double MaxValue { get; set; }
}