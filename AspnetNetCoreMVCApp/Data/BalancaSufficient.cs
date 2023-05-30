namespace AspnetNetCoreMVCApp.Data
{
  public class BalancaSufficient:ApplicationException
  {
    public BalancaSufficient():base("işlem için bakiye yetersiz")
    {

    }
  }
}
