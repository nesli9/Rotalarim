using System.ComponentModel.DataAnnotations;

namespace Rotalarim.Models
{
    public class LoginViewModel
    {
        [Required] //veri girilmesi zorunlu yapmak için kullanılır
        [EmailAddress] //email formatında yazılması gerektiğini belirtir
        [Display(Name = "Eposta")]
        public string? Email { get; set;}

        [Required]  
        [StringLength(10, ErrorMessage = "{0} alanı en  az {2} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string? Password { get; set; }
    }
}