using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace AspnetNetCoreMVCApp.Entities.Configurations
{
  public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
  {
    public void Configure(EntityTypeBuilder<Customer> builder)
    {


      builder.HasIndex(e => e.City, "City");

      builder.HasIndex(e => e.CompanyName, "CompanyName");

      builder.HasIndex(e => e.PostalCode, "PostalCode");

      builder.HasIndex(e => e.Region, "Region");

      builder.Property(e => e.CustomerId)
          .HasMaxLength(5)
          .HasColumnName("CustomerID")
          .IsFixedLength();

      builder.Property(e => e.Address).HasMaxLength(60);

      builder.Property(e => e.City).HasMaxLength(15);

      builder.Property(e => e.CompanyName).HasMaxLength(40);

      builder.Property(e => e.ContactName).HasMaxLength(30);

      builder.Property(e => e.ContactTitle).HasMaxLength(30);

      builder.Property(e => e.Country).HasMaxLength(15);

      builder.Property(e => e.Fax).HasMaxLength(24);

      builder.Property(e => e.Phone).HasMaxLength(24);

      builder.Property(e => e.PostalCode).HasMaxLength(10);

      builder.Property(e => e.Region).HasMaxLength(15);

      builder.HasMany(d => d.CustomerTypes)
          .WithMany(p => p.Customers)
          .UsingEntity<Dictionary<string, object>>(
              "CustomerCustomerDemo",
              l => l.HasOne<CustomerDemographic>().WithMany().HasForeignKey("CustomerTypeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CustomerCustomerDemo"),
              r => r.HasOne<Customer>().WithMany().HasForeignKey("CustomerId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CustomerCustomerDemo_Customers"),
              j =>
              {
                j.HasKey("CustomerId", "CustomerTypeId").IsClustered(false);

                j.ToTable("CustomerCustomerDemo");

                j.IndexerProperty<string>("CustomerId").HasMaxLength(5).HasColumnName("CustomerID").IsFixedLength();

                j.IndexerProperty<string>("CustomerTypeId").HasMaxLength(10).HasColumnName("CustomerTypeID").IsFixedLength();

              });




  }
  }
}
