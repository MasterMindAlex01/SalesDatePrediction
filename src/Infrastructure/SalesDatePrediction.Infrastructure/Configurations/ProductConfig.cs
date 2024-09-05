using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDatePrediction.Domain.Entities;

namespace SalesDatePrediction.Infrastructure.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "Production");

            builder.HasIndex(e => e.Categoryid, "idx_nc_categoryid");

            builder.HasIndex(e => e.Productname, "idx_nc_productname");

            builder.HasIndex(e => e.Supplierid, "idx_nc_supplierid");

            builder.Property(e => e.Productid).HasColumnName("productid");
            builder.Property(e => e.Categoryid).HasColumnName("categoryid");
            builder.Property(e => e.Discontinued).HasColumnName("discontinued");
            builder.Property(e => e.Productname)
                .HasMaxLength(40)
                .HasColumnName("productname");
            builder.Property(e => e.Supplierid).HasColumnName("supplierid");
            builder.Property(e => e.Unitprice)
                .HasColumnType("money")
                .HasColumnName("unitprice");

            builder.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.Categoryid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Categories");

            builder.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.Supplierid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Suppliers");
        }
    }
}
