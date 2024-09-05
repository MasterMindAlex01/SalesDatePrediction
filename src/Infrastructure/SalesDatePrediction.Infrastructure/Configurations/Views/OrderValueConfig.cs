using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDatePrediction.Domain.Entities;

namespace SalesDatePrediction.Infrastructure.Configurations
{
    public class OrderValueConfig : IEntityTypeConfiguration<OrderValue>
    {
        public void Configure(EntityTypeBuilder<OrderValue> builder)
        {
            builder
                .HasNoKey()
                .ToView("OrderValues", "Sales");

            builder.Property(e => e.Custid).HasColumnName("custid");
            builder.Property(e => e.Empid).HasColumnName("empid");
            builder.Property(e => e.Orderdate)
                .HasColumnType("datetime")
                .HasColumnName("orderdate");
            builder.Property(e => e.Orderid).HasColumnName("orderid");
            builder.Property(e => e.Shipperid).HasColumnName("shipperid");
            builder.Property(e => e.Val)
                .HasColumnType("numeric(12, 2)")
                .HasColumnName("val");
        }
    }
}
