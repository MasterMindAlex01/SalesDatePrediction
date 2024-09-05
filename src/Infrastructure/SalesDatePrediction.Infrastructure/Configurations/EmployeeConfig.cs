using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDatePrediction.Domain.Entities;

namespace SalesDatePrediction.Infrastructure.Configurations
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Empid);

            builder.ToTable("Employees", "HR");

            builder.HasIndex(e => e.Lastname, "idx_nc_lastname");

            builder.HasIndex(e => e.Postalcode, "idx_nc_postalcode");

            builder.Property(e => e.Empid).HasColumnName("empid");
            builder.Property(e => e.Address)
                .HasMaxLength(60)
                .HasColumnName("address");
            builder.Property(e => e.Birthdate)
                .HasColumnType("datetime")
                .HasColumnName("birthdate");
            builder.Property(e => e.City)
                .HasMaxLength(15)
                .HasColumnName("city");
            builder.Property(e => e.Country)
                .HasMaxLength(15)
                .HasColumnName("country");
            builder.Property(e => e.Firstname)
                .HasMaxLength(10)
                .HasColumnName("firstname");
            builder.Property(e => e.Hiredate)
                .HasColumnType("datetime")
                .HasColumnName("hiredate");
            builder.Property(e => e.Lastname)
                .HasMaxLength(20)
                .HasColumnName("lastname");
            builder.Property(e => e.Mgrid).HasColumnName("mgrid");
            builder.Property(e => e.Phone)
                .HasMaxLength(24)
                .HasColumnName("phone");
            builder.Property(e => e.Postalcode)
                .HasMaxLength(10)
                .HasColumnName("postalcode");
            builder.Property(e => e.Region)
                .HasMaxLength(15)
                .HasColumnName("region");
            builder.Property(e => e.Title)
                .HasMaxLength(30)
                .HasColumnName("title");
            builder.Property(e => e.Titleofcourtesy)
                .HasMaxLength(25)
                .HasColumnName("titleofcourtesy");

            builder.HasOne(d => d.Mgr).WithMany(p => p.InverseMgr)
                .HasForeignKey(d => d.Mgrid)
                .HasConstraintName("FK_Employees_Employees");
        }
    }
}
