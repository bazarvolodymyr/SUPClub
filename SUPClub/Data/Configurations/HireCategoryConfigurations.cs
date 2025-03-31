using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SUPClub.Data.Entities;

namespace SUPClub.Data.Configurations
{
    public class HireCategoryConfigurations : IEntityTypeConfiguration<HireCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<HireCategoryEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ImageUrl).HasMaxLength(300);
        }
    }
}
