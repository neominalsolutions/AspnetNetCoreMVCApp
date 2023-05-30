using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace AspnetNetCoreMVCApp.Models
{
  public class DepositDto
  {
    [Min(5,ErrorMessage = "En az 5 TL para çekebiliriz")]
    [Max(30000, ErrorMessage = "En falza 30000 TL para çekebiliriz")]
    public decimal Amount { get; set; }


    [Required(ErrorMessage ="Hesap numarasını girmelisiniz")]
    public string AccountNumber { get; set; }

    public string Type { get; set; } = "Para Çekme";
  }
}
