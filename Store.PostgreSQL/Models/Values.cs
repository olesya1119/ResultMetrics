using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ResultMetrics.Store.PostgreSQL.Models;

public class Values
{
    public long Id { get; set; }
    public string FileName { get; set; } = null!;
    public DateTime Date { get; set; }
    public double ExecutionTime { get; set; }
    public double Value { get; set; }

    internal sealed class ValuesConfiguration : IEntityTypeConfiguration<Values>
    {
        public void Configure(EntityTypeBuilder<Values> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FileName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Date).IsRequired().HasColumnType("timestamp without time zone");
            builder.Property(x => x.ExecutionTime).IsRequired();
            builder.Property(x => x.Value).IsRequired();
            
            builder.HasIndex(x => x.FileName);
            builder.HasIndex(x => x.Date);
        }
    }
}