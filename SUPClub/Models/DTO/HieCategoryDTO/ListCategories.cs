namespace SUPClub.Models.DTO.HieCategoryDTO
{
    public class ListCategories
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<SubCategory> subCategory { get; set; } = new();
        
    }
    public class SubCategory
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}            
