using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ResultMetrics.Store.PostgreSQL.Models;

public class Results
{
    public long Id { get; set; }
    public string FileName { get; set; } = null!;
    public double DeltaDateInSeconds { get; set; }
    public DateTime MinDate { get; set; }
    public double AvgExecutionTime { get; set; }
    public double AvgValue { get; set; }
    public double MedianValue { get; set; }
    public double MinValue { get; set; }
    public double MaxValue { get; set; }

    internal sealed class ResultsConfiguration : IEntityTypeConfiguration<Results>
    {
        public void Configure(EntityTypeBuilder<Results> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FileName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DeltaDateInSeconds).IsRequired();
            builder.Property(x => x.MinDate).IsRequired().HasColumnType("timestamp without time zone");
            builder.Property(x => x.AvgExecutionTime).IsRequired();
            builder.Property(x => x.AvgValue).IsRequired();
            builder.Property(x => x.MedianValue).IsRequired();
            builder.Property(x => x.MinValue).IsRequired();
            builder.Property(x => x.MaxValue).IsRequired();
        }
    }
}