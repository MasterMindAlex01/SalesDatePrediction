using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDatePrediction.Domain.Entities;

namespace SalesDatePrediction.Infrastructure.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", "Production");

            builder.HasIndex(e => e.Categoryname, "categoryname");

            builder.Property(e => e.Categoryid).HasColumnName("categoryid");
            builder.Property(e => e.Categoryname)
                .HasMaxLength(15)
                .HasColumnName("categoryname");
            builder.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
        }
    }
}
