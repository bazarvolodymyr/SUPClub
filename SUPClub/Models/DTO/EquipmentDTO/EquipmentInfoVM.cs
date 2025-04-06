namespace SUPClub.Models.DTO.EquipmentDTO
{
    public class EquipmentInfoVM 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public string? SubCategoryName { get; set; }
        public string? CategoryName { get; set; }
        public bool IsActive { get; set; }
        public string? CreateAt { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
