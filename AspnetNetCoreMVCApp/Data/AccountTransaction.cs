namespace AspnetNetCoreMVCApp.Data
{
  public class AccountTransaction
  {
    public AccountTransaction(string type, decimal amount, string accountId)
    {
      Id = Guid.NewGuid().ToString();
      Type = type;
      Amount = amount;
      AccountId = accountId;
    }

    public string Id { get; init; }
    public string Type { get; init; } // Deposit, WithDraw

    public decimal Amount { get; init; }

    public string AccountId { get; init; }

    // navigation property tanımı
    public Account Account { get; set; }


    // account.find(id).transactions.find(id).setDate(new Date());


  }
}
