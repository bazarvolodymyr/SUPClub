using System.ComponentModel.DataAnnotations;

namespace SUPClub.Models.DTO.HieCategoryDTO
{
    public class EditHireCategoryVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(HireCategory.MAX_LENGHT_NAME, ErrorMessage = "Максимальна довжина імені {1} символів")]
        [Display(Name = "Назва категорії")]
        public string? Name { get; set; }
        [StringLength(HireCategory.MAX_LENGHT_IMAGE_URL, ErrorMessage = "Максимальна довжина імені зображення {1} символів")]
        [Display(Name = "Титульна картинка")]
        public string? ImageUrl { get; set; }
        [Display(Name = "Активувати?")]
        public bool IsActive { get; set; }
    }
}
