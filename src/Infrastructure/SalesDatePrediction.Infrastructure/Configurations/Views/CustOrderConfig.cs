using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDatePrediction.Domain.Entities;

namespace SalesDatePrediction.Infrastructure.Configurations
{
    public class CustOrderConfig : IEntityTypeConfiguration<CustOrder>
    {
        public void Configure(EntityTypeBuilder<CustOrder> builder)
        {
            builder
                .HasNoKey()
                .ToView("CustOrders", "Sales");

            builder.Property(e => e.Custid).HasColumnName("custid");
            builder.Property(e => e.Ordermonth)
                .HasColumnType("datetime")
                .HasColumnName("ordermonth");
            builder.Property(e => e.Qty).HasColumnName("qty");
        }
    }
}
