namespace AspnetNetCoreMVCApp.Models
{
  public class WithDrawDto
  {
    public decimal Amount { get; set; }
    public string AccountNumber { get; set; }

    public string Type { get; set; } = "Para Yatırma";
  }
}
