using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDatePrediction.Domain.Entities;

namespace SalesDatePrediction.Infrastructure.Configurations
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(e => e.Custid);

            builder.ToTable("Customers", "Sales");

            builder.HasIndex(e => e.City, "idx_nc_city");

            builder.HasIndex(e => e.Companyname, "idx_nc_companyname");

            builder.HasIndex(e => e.Postalcode, "idx_nc_postalcode");

            builder.HasIndex(e => e.Region, "idx_nc_region");

            builder.Property(e => e.Custid).HasColumnName("custid");
            builder.Property(e => e.Address)
                .HasMaxLength(60)
                .HasColumnName("address");
            builder.Property(e => e.City)
                .HasMaxLength(15)
                .HasColumnName("city");
            builder.Property(e => e.Companyname)
                .HasMaxLength(40)
                .HasColumnName("companyname");
            builder.Property(e => e.Contactname)
                .HasMaxLength(30)
                .HasColumnName("contactname");
            builder.Property(e => e.Contacttitle)
                .HasMaxLength(30)
                .HasColumnName("contacttitle");
            builder.Property(e => e.Country)
                .HasMaxLength(15)
                .HasColumnName("country");
            builder.Property(e => e.Fax)
                .HasMaxLength(24)
                .HasColumnName("fax");
            builder.Property(e => e.Phone)
                .HasMaxLength(24)
                .HasColumnName("phone");
            builder.Property(e => e.Postalcode)
                .HasMaxLength(10)
                .HasColumnName("postalcode");
            builder.Property(e => e.Region)
                .HasMaxLength(15)
                .HasColumnName("region");
        }
    }
}
