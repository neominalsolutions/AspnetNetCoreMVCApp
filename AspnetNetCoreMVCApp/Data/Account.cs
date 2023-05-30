namespace AspnetNetCoreMVCApp.Data
{
  // nesneler arasındaki ilişkileri 
  public class Account // root entity
  {
    public string Id { get; init; }

    public string? AccountNumber { get; init; }

    public string? CustomerId { get; set; }


    public decimal Balance { get; private set; } = 0;

    // child
    private List<AccountTransaction> _transactions = new List<AccountTransaction>();
    public IReadOnlyCollection<AccountTransaction> Transactions => _transactions;


    public Account(string accountNumber)
    {
      Id = Guid.NewGuid().ToString();
      AccountNumber = accountNumber;
    }


    // para çekme ve para gönderme işlemi

    /// <summary>
    /// Para Yatırma işlemi
    /// </summary>
    /// <param name="amount"> miktar </param>
    public void WithDraw(decimal amount)
    {
      this.Balance += amount;

      _transactions.Add(new AccountTransaction("WithDraw", amount, this.Id));

    }

    /// <summary>
    /// Para çekme işlemi
    /// </summary>
    /// <param name="amount"></param>
    public void Deposit(decimal amount)
    {

      if(this.Balance - amount < 0)
      {
        throw new BalancaSufficient();
      }

      this.Balance -= amount;

      _transactions.Add(new AccountTransaction("Deposit", amount, this.Id));
    }

  }
}
