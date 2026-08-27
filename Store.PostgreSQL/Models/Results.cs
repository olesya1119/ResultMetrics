using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ResultMetrics.Store.PostgreSQL.Models;

public class Results
{
    public long Id { get; set; }
    public string FileName { get; set; } = null!;
    public int DeltaTimeInSeconds { get; set; }
    public DateTime MinDate { get; set; }
    public double AverageExecutionTime { get; set; }
    public double AverageValue { get; set; }
    public double MedianValue { get; set; }
    public double MinValue { get; set; }
    public double MaxValue { get; set; }

    internal sealed class ResultsConfiguration : IEntityTypeConfiguration<Results>
    {
        public void Configure(EntityTypeBuilder<Results> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FileName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DeltaTimeInSeconds).IsRequired();
            builder.Property(x => x.MinDate).IsRequired();
            builder.Property(x => x.AverageExecutionTime).IsRequired();
            builder.Property(x => x.AverageValue).IsRequired();
            builder.Property(x => x.MedianValue).IsRequired();
            builder.Property(x => x.MinValue).IsRequired();
            builder.Property(x => x.MaxValue).IsRequired();
        }
    }
}