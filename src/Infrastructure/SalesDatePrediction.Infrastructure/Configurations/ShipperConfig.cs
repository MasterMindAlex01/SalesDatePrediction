using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDatePrediction.Domain.Entities;

namespace SalesDatePrediction.Infrastructure.Configurations
{
    public class ShipperConfig : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {
            builder.ToTable("Shippers", "Sales");

            builder.Property(e => e.Shipperid).HasColumnName("shipperid");
            builder.Property(e => e.Companyname)
                .HasMaxLength(40)
                .HasColumnName("companyname");
            builder.Property(e => e.Phone)
                .HasMaxLength(24)
                .HasColumnName("phone");
        }
    }
}
