using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDatePrediction.Domain.Entities;

namespace SalesDatePrediction.Infrastructure.Configurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "Sales");

            builder.HasIndex(e => e.Custid, "idx_nc_custid");

            builder.HasIndex(e => e.Empid, "idx_nc_empid");

            builder.HasIndex(e => e.Orderdate, "idx_nc_orderdate");

            builder.HasIndex(e => e.Shippeddate, "idx_nc_shippeddate");

            builder.HasIndex(e => e.Shipperid, "idx_nc_shipperid");

            builder.HasIndex(e => e.Shippostalcode, "idx_nc_shippostalcode");

            builder.Property(e => e.Orderid).HasColumnName("orderid");
            builder.Property(e => e.Custid).HasColumnName("custid");
            builder.Property(e => e.Empid).HasColumnName("empid");
            builder.Property(e => e.Freight)
                .HasColumnType("money")
                .HasColumnName("freight");
            builder.Property(e => e.Orderdate)
                .HasColumnType("datetime")
                .HasColumnName("orderdate");
            builder.Property(e => e.Requireddate)
                .HasColumnType("datetime")
                .HasColumnName("requireddate");
            builder.Property(e => e.Shipaddress)
                .HasMaxLength(60)
                .HasColumnName("shipaddress");
            builder.Property(e => e.Shipcity)
                .HasMaxLength(15)
                .HasColumnName("shipcity");
            builder.Property(e => e.Shipcountry)
                .HasMaxLength(15)
                .HasColumnName("shipcountry");
            builder.Property(e => e.Shipname)
                .HasMaxLength(40)
                .HasColumnName("shipname");
            builder.Property(e => e.Shippeddate)
                .HasColumnType("datetime")
                .HasColumnName("shippeddate");
            builder.Property(e => e.Shipperid).HasColumnName("shipperid");
            builder.Property(e => e.Shippostalcode)
                .HasMaxLength(10)
                .HasColumnName("shippostalcode");
            builder.Property(e => e.Shipregion)
                .HasMaxLength(15)
                .HasColumnName("shipregion");

            builder.HasOne(d => d.Cust).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Custid)
                .HasConstraintName("FK_Orders_Customers");

            builder.HasOne(d => d.Emp).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Empid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Employees");

            builder.HasOne(d => d.Shipper).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Shipperid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Shippers");
        }
    }
}
