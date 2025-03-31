namespace SUPClub.Data.Entities
{
    public class HireSubCategoryEntity : EntityBase
    {
        public int? HireCategoryId { get; set; }
        public HireCategoryEntity? HireCategory { get; set; }
        public ICollection<EquipmentEntity>? Equipments { get; set; }
    }
}
