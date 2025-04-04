using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SUPClub.Models.DTO.AccountDTO
{
    public class LoginVM
    {
        [Required]
        [Display(Name = "Логін")]
        public string? UserName { get; set; }
        [Required]
        [UIHint("password")]
        [Display(Name = "Пароль")]
        public string? Password { get; set; }
        [Display(Name = "Запам'ятати мене?")]
        public bool RememberMe { get; set; }
    }
}
