namespace SUPClub.Data.Entities
{
    public class ReservationEntity
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public int EquipmentNumber { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public decimal? TotalPrice { get; set; }
        public int BookingId { get; set; }
        public EquipmentEntity? Equipment{ get; set; }
        public BookingEntity? Booking { get; set; }
    }
}
