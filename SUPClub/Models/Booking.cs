using SUPClub.Models.Enums;

namespace SUPClub.Models
{
    public class Booking
    {
        private List<Reservation> _reservations;
        public int Id { get; private set; }
        public string? CustomerId { get; private set; }
        public decimal TotalPrice { get; private set; }
        public string? Description { get; private set; }
        public BookingStatus Status { get; private set; }
        public DateTime? CreateDate { get; private set; }
        public DateTime? UpdateDate { get; private set; }
        public List<Reservation> Reservations 
        { 
            get { return _reservations; }
        }
        private Booking(
            string? customerId,
            decimal totalPrice,
            string? description,
            BookingStatus status,
            DateTime createDate,
            DateTime updateDate,
            List<Reservation> reservations)
        {
            CustomerId= customerId;
            TotalPrice= totalPrice;
            Description= description;
            Status= status;
            CreateDate= createDate;
            UpdateDate= updateDate;
            _reservations = reservations;
        }
        public static Booking Create(string customerId, string? description)
        {
            return new Booking(customerId, 0, description, BookingStatus.Reserved,
                DateTime.Now, DateTime.Now, new());
        }
    }
}
