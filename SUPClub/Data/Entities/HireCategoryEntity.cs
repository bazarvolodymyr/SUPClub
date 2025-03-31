namespace SUPClub.Data.Entities
{
    public class HireCategoryEntity : EntityBase
    {
        public string? ImageUrl { get; set; }
        public ICollection<HireSubCategoryEntity>? HireSubCategories { get; set; }
        public ICollection<EquipmentEntity>? Equipments { get; set; }
    }
}
