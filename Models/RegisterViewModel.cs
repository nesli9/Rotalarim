using System.ComponentModel.DataAnnotations;

namespace Rotalarim.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string? UserName { get; set; }

        [Required]
        [Display(Name = "Ad Soyad")]
        public string? Name { get; set; }

        [Required]//veri girilmesi zorunlu yapmak için kullanılır
        [EmailAddress]//email formatında yazılması gerektiğini belirtir
        [Display(Name = "Eposta")]
        public string? Email { get; set;}

        [Required]  
        [StringLength(10, ErrorMessage = "{0} alanı en  az {2} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string? Password { get; set; }

        [Required]  
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Parolanız eşleşmiyor.")]//parola eşleşmediğinde uyarı verir
        [Display(Name = "Parola Tekrar")]
        public string? ConfirmPassword { get; set; }
    }
}