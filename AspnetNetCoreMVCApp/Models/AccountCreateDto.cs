using System.ComponentModel.DataAnnotations;

namespace AspnetNetCoreMVCApp.Models
{
  public class AccountCreateDto
  {
    [Required(ErrorMessage ="Hesap Numarası alanı bış geçilemez")]
    public string AccountNumber { get; set; }

  }
}
