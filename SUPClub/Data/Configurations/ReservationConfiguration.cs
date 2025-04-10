using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SUPClub.Data.Entities;

namespace SUPClub.Data.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<ReservationEntity>
    {
        public void Configure(EntityTypeBuilder<ReservationEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Booking)
                .WithMany(r => r.Reservations)
                .HasForeignKey(k => k.BookingId);
            builder.HasOne(x => x.Equipment)
                .WithMany(c => c.Reservations)
                .HasForeignKey(k => k.EquipmentId);
        }
    }
}
