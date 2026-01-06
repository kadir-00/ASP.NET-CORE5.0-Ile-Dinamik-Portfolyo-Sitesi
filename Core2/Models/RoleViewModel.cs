using System.ComponentModel.DataAnnotations;

namespace Core2.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Lutfen Rol Adi Giriniz")]
        public string Name { get; set; }
    }
}
