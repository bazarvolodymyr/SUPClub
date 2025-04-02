using System.ComponentModel.DataAnnotations;

namespace SUPClub.Models.DTO
{
    public class CreateHireCategoryVM
    {
        [Required]
        [StringLength(HireCategory.MAX_LENGHT_NAME, ErrorMessage = "Максимальна довжина імені {1} символів")]
        [Display(Name = "Назва категорії")]
        public string? Name { get; set; }
        [StringLength(HireCategory.MAX_LENGHT_IMAGE_URL, ErrorMessage = "Максимальна довжина імені {1} символів")]
        [Display(Name = "Титульна картинка")]
        public string? ImageUrl { get; set; }
        [Display(Name = "Активувати?")]
        public bool IsActive { get; set; }
    }
}
