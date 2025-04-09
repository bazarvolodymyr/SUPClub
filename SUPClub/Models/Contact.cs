using SUPClub.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace SUPClub.Models
{
    public class Contact
    {
        public const int MAX_LENGHT_TEXT = 300;
        public const int MAX_LENGHT_IMAGE_URL = 300;
        public const int MAX_LENGHT_SOURCE = 2048;
        public int Id { get; set; }
        [StringLength(MAX_LENGHT_IMAGE_URL, ErrorMessage = "Максимальна довжина імені зображення {1} символів")]
        [Display(Name = "Icon")]
        public string? IconUrl { get; set; }
        [StringLength(MAX_LENGHT_TEXT, ErrorMessage = "Максимальна довжина тексу {1} символів")]
        [Display(Name = "Текст")]
        public string? Text { get; set; }
        [StringLength(MAX_LENGHT_SOURCE, ErrorMessage = "Максимальна довжина джерела {1} символів")]
        [Display(Name = "Джерело")]
        public string? Source { get; set; }
        [Display(Name = "Тип")]
        public ContactType? Type { get; set; }
        [Display(Name = "Рейтинг")]
        public int Rank { get; set; }
    }
}
