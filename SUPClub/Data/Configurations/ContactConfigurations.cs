using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SUPClub.Data.Entities;
using SUPClub.Models;

namespace SUPClub.Data.Configurations
{
    public class ContactConfigurations : IEntityTypeConfiguration<ContactEntity>
    {
        public void Configure(EntityTypeBuilder<ContactEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IconUrl).HasMaxLength(Contact.MAX_LENGHT_IMAGE_URL);
            builder.Property(x => x.Text).HasMaxLength(Contact.MAX_LENGHT_TEXT);
            builder.Property(x => x.Source).HasMaxLength(Contact.MAX_LENGHT_SOURCE);

        }
    }
}
