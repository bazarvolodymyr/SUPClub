using SUPClub.Models.DTO.HireSubCategoryDTO;

namespace SUPClub.Models.DTO.HieCategoryDTO
{
    public class CategoryView
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public List<SubCategoryView> subCategory { get; set; } = new();
    }
    
}            
