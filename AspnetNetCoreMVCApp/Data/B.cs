namespace AspnetNetCoreMVCApp.Data
{
  public class B
  {
    public int Id { get; set; }

    public ICollection<A> AList { get; set; }
  }
}
