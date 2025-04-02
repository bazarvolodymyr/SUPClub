using System.ComponentModel.DataAnnotations;

namespace SUPClub.Models.DTO
{
    public class RegisterUserVM
    {
        [Required]
        [StringLength(100, ErrorMessage ="Максимальна довжина імені 100 символів")]
        [Display(Name = "Ім'я")]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Максимальна довжина фамілії 100 символів")]
        [Display(Name = "Фамілія")]
        public string? LastName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Телефон")]
        public string? Phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string? Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "{0} має бути від {2} до {1} символів", MinimumLength = 6)]
        [Display(Name = "Логін")]
        public string? UserName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "{0} має бути від {2} до {1} символів", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string? Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Паролі не збігаотся")]
        [DataType(DataType.Password)]
        [Display(Name = "Підтвердити пароль")]
        public string? PasswordConfirm { get; set; }
    }
}
