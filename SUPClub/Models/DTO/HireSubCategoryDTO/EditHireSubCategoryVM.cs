using System.ComponentModel.DataAnnotations;

namespace SUPClub.Models.DTO.HireSubCategoryDTO
{
    public class EditHireSubCategoryVM 
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Назва не може бути пустою")]
        [StringLength(HireSubCategory.MAX_LENGHT_NAME, ErrorMessage = "Максимальна довжина імені {1} символів")]
        [Display(Name = "Назва під категорії")]
        public string? Name { get; set; }

        [Display(Name = "Категорія")]
        public int? HireCategoryId { get; set; }
        [Display(Name = "Активувати?")]
        public bool IsActive { get; set; }
    }
}
