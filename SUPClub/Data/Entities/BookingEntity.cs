using SUPClub.Models.Enums;

namespace SUPClub.Data.Entities
{
    public class BookingEntity
    {
        public int Id { get; set; }
        public string? CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Description { get; set; }
        public BookingStatus Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public List<ReservationEntity>? Reservations { get; set; }
    }
}
