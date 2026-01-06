using System.ComponentModel.DataAnnotations;

namespace Core2.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lutfen adinizi girin")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lutfen soyadinizi girin")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lutfen kullanıci adini girin")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lutfen sifreyi girin")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lutfen sifreyi tekrar girin")]
        [Compare("Password", ErrorMessage = "Sifreler uyumlu degil!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Lutfen mail adresini girin")]
        public string Mail { get; set; }
    }
}
