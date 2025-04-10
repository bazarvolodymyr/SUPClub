namespace SUPClub.Models
{
    public class Reservation
    {
        public int Id { get; private set; }
        public int EquipmentId { get; private set; }
        public int EquipmentNumber { get; private set; }
        public DateTime? Start { get; private set; }
        public DateTime? End { get; private set; }
        public decimal? TotalPrice { get; private set; }
        public int BookingId { get; private set; }
        private Reservation(
            int equipmentId, 
            int equipmentNumber, 
            DateTime start, 
            DateTime end, 
            decimal? totalPrice, 
            int bookingId)
        {
            EquipmentId = equipmentId;
            EquipmentNumber = equipmentNumber;
            Start = start;
            End = end;
            TotalPrice = totalPrice;
            BookingId = bookingId;
        }
        public static Reservation Create(int equipmentId, int equipmentNumber, DateTime start,
            DateTime end, decimal totalPrice, int bookingId)
        {
            if(end <= start)
            {
                throw new ArgumentException(nameof(end));
            }
            return new Reservation(equipmentId, equipmentNumber, start, end, totalPrice, bookingId);
        }
    }
}
