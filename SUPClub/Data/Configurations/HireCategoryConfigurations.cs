using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SUPClub.Data.Entities;
using SUPClub.Models;

namespace SUPClub.Data.Configurations
{
    public class HireCategoryConfigurations : IEntityTypeConfiguration<HireCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<HireCategoryEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(HireCategory.MAX_LENGHT_NAME);
            builder.Property(x => x.ImageUrl).HasMaxLength(HireCategory.MAX_LENGHT_IMAGE_URL);
            builder.Property(e => e.CreateById).IsRequired().HasMaxLength(HireCategory.MAX_LENGHT_CREATE_BY_ID);
        }
    }
}
