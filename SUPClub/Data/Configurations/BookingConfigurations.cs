using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SUPClub.Data.Entities;

namespace SUPClub.Data.Configurations
{
    public class BookingConfigurations : IEntityTypeConfiguration<BookingEntity>
    {
        public void Configure(EntityTypeBuilder<BookingEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CustomerId).IsRequired();
        }
    }
}
