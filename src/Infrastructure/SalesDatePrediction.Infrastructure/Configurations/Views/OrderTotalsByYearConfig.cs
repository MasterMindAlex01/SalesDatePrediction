using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDatePrediction.Domain.Entities;

namespace SalesDatePrediction.Infrastructure.Configurations
{
    public class OrderTotalsByYearConfig : IEntityTypeConfiguration<OrderTotalsByYear>
    {
        public void Configure(EntityTypeBuilder<OrderTotalsByYear> builder)
        {
            builder
                .HasNoKey()
                .ToView("OrderTotalsByYear", "Sales");

            builder.Property(e => e.Orderyear).HasColumnName("orderyear");
            builder.Property(e => e.Qty).HasColumnName("qty");
        }
    }
}
