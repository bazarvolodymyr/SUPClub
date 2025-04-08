namespace SUPClub.Models.DTO.EquipmentDTO
{
    public class EquipmentView
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? DescriptionShort { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
    }
}
