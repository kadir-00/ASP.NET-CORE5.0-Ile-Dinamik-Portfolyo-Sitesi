using System.ComponentModel.DataAnnotations;

namespace Core2.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Kullanici adini giriniz...!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Sifrenizi giriniz...!")]
        public string Password { get; set; }
    }
}
