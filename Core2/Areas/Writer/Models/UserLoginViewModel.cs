using System.ComponentModel.DataAnnotations;

namespace Core2.Areas.Writer.Models
{
    public class UserLoginViewModel
    {
        [Display(Name ="Kullanici Adi")]
        [Required(ErrorMessage ="Kullanici Adini Giriniz")]
        public string UserName { get; set; }

        [Display(Name = "Sifre")]
        [Required(ErrorMessage = "Sifreyi Giriniz")]
        public string Password { get; set; }
    }
}
