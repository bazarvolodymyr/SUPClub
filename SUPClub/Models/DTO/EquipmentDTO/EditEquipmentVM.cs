using System.ComponentModel.DataAnnotations;

namespace SUPClub.Models.DTO.EquipmentDTO
{
    public class EditEquipmentVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Назва не може бути пустою")]
        [StringLength(Equipment.MAX_LENGHT_NAME, ErrorMessage = "Максимальна довжина назви {1} символів")]
        [Display(Name = "Назва")]
        public string? Name { get; set; }
        [StringLength(Equipment.MAX_LENGHT_DESCRIPTION_SHORT,
            ErrorMessage = "Максимальна довжина короткого опису {1} символів")]
        [Display(Name = "Короткий опис")]
        public string? DescriptionShort { get; set; }
        [StringLength(Equipment.MAX_LENGHT_DESCRIPTION, 
            ErrorMessage = "Максимальна довжина опису {1} символів")]
        [Display(Name = "Опис спорядження")]
        public string? Description { get; set; }
        [StringLength(Equipment.MAX_LENGHT_PHOTO_URL, ErrorMessage = "Максимальна довжина імені зображення {1} символів")]
        [Display(Name = "Фото")]
        public string? Photo { get; set; }
        [Display(Name = "Наявна кількість")]
        public int? Quantity { get; set; }
        [Display(Name = "Ціна")]
        public decimal? Price { get; set; }
        [Display(Name = "Підкатегорія")]
        public int? HireSubCategoryId { get; set; }
        [Display(Name = "Категорія")]
        public int? HireCategoryId { get; set; }
        [Display(Name = "Активувати?")]
        public bool IsActive { get; set; }
        
    }
}
