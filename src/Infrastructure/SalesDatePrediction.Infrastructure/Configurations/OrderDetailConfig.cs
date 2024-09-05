using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDatePrediction.Domain.Entities;

namespace SalesDatePrediction.Infrastructure.Configurations
{
    public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(e => new { e.Orderid, e.Productid });

            builder.ToTable("OrderDetails", "Sales");

            builder.HasIndex(e => e.Orderid, "idx_nc_orderid");

            builder.HasIndex(e => e.Productid, "idx_nc_productid");

            builder.Property(e => e.Orderid).HasColumnName("orderid");
            builder.Property(e => e.Productid).HasColumnName("productid");
            builder.Property(e => e.Discount)
                .HasColumnType("numeric(4, 3)")
                .HasColumnName("discount");
            builder.Property(e => e.Qty)
                .HasDefaultValue((short)1)
                .HasColumnName("qty");
            builder.Property(e => e.Unitprice)
                .HasColumnType("money")
                .HasColumnName("unitprice");

            builder.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.Orderid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Orders");

            builder.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.Productid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Products");
        }
    }
}
