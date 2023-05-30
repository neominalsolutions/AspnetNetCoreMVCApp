namespace AspnetNetCoreMVCApp.Data
{
  

  /// <summary>
  /// Banka Müşterisi
  /// </summary>
  public class Customer
  {
    // constructordan gönderilecek olan değerleri init yaparız
    public string CustomerNumber { get;  init; }
    public string Id { get; init; }

    // ekranda sadece okunancak olan değerler için readonly tanımları yaparız.
    public IReadOnlyCollection<Account> Accounts { get; }


    public Customer(string customerNumber)
    {
      this.Id = Guid.NewGuid().ToString();
      this.CustomerNumber = customerNumber;

    }


    //public void SetCustomerNumber(string customerNumber)
    //{
    //  this.CustomerNumber = customerNumber;
    //}
  }
}
