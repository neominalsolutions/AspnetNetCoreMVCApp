namespace AspnetNetCoreMVCApp.Data
{
  public class A
  {
    public int Id { get; set; }
    public ICollection<B> BList { get; set; }
  }
}
