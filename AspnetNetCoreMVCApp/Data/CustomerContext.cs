using AspnetNetCoreMVCApp.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AspnetNetCoreMVCApp.Data
{
  public class CustomerContext:DbContext
  {

    public CustomerContext()
    {

    }

    public CustomerContext(DbContextOptions<CustomerContext> opt):base(opt)
    {

    }

    // ddd yöntemlerine göre root entity üzerinden sorgulama yapıyoruz
    // child entity tek başına güncellenememli yada ekleme çıkarma yapılmamalıdır. bu sebeple DbSet tanımı yapmak yazılımıcının hatalı kod yazmasına sebep olur.
    public DbSet<Account>  Accounts { get; set; }
    //public DbSet<AccountTransaction> AccountTransactions { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<A> ATable { get; set; }
    public DbSet<B> BTable { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new AccountConfig());

      base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
      return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
      return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

  }
}
