using System.ComponentModel.DataAnnotations;

namespace Core2.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lutfen Isminiz Giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lutfen Soyisminizi Giriniz")]
        public string Surname { get; set; }

        [Required(ErrorMessage ="Lutfen Kullanici Adini Giriniz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lutfen Resim Linki Giriniz")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Lutfen Sifreyi Giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lutfen Sifre Tekrarini Giriniz")]
        [Compare("Password",ErrorMessage ="Sifreler Uyumlu Degil")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Lutfen Mailinizi Giriniz")]
        public string Mail { get; set; }
    }
}
