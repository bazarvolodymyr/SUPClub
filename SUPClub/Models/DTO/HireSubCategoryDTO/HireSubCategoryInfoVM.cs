namespace SUPClub.Models.DTO.HireSubCategoryDTO
{
    public class HireSubCategoryInfoVM : EditHireSubCategoryVM
    {
        public string? CategoryName { get; set; }
        public string? CreateAt { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
