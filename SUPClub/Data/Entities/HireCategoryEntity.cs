namespace SUPClub.Data.Entities
{
    public class HireCategoryEntity : EntityBase
    {
        public string? ImageUrl { get; set; }
        public ICollection<HireSubCategoryEntity> HireSubCategories { get; set; } = new List<HireSubCategoryEntity>();
        public ICollection<EquipmentEntity> Equipments { get; set; } = new List<EquipmentEntity>();
    }
}
