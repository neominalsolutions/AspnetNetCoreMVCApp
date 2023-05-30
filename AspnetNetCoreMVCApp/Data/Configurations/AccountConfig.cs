using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspnetNetCoreMVCApp.Data.Configurations
{
  public class AccountConfig : IEntityTypeConfiguration<Account>
  {
    public void Configure(EntityTypeBuilder<Account> builder)
    {
      builder.HasKey(c => c.Id);
      builder.Property(x => x.AccountNumber).IsRequired().HasMaxLength(50).IsUnicode(false).HasColumnName("MusteriNo");
      builder.ToTable("Musteri");

      // single associations
      // builder.HasMany(x => x.Transactions);

      // çift taraflı ilişki ama önerilmiyor, double associations  
      builder.HasMany(x => x.Transactions).WithOne(x=> x.Account).HasForeignKey(x=> x.AccountId);


    }
  }
}
