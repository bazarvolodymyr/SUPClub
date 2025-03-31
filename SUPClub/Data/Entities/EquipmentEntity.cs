namespace SUPClub.Data.Entities
{
    public class EquipmentEntity : EntityBase
    {
        public string? DescriptionShort { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; } 
        public int? HireSubCategoryId { get; set; }
        public int? HireCategoryId { get; set; }
        public HireSubCategoryEntity? HireSubCategory { get; set; }
        public HireCategoryEntity? HireCategory { get; set; }
    }
}
