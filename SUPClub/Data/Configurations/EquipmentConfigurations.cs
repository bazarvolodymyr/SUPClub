using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SUPClub.Data.Entities;
using SUPClub.Models;

namespace SUPClub.Data.Configurations
{
    public class EquipmentConfigurations : IEntityTypeConfiguration<EquipmentEntity>
    {
        public void Configure(EntityTypeBuilder<EquipmentEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(Equipment.MAX_LENGHT_NAME);
            builder.Property(e => e.DescriptionShort).HasMaxLength(Equipment.MAX_LENGHT_DESCRIPTION_SHORT);
            builder.Property(e => e.Description).HasMaxLength(Equipment.MAX_LENGHT_DESCRIPTION);
            builder.Property(e => e.Photo).HasMaxLength(Equipment.MAX_LENGHT_PHOTO_URL);
            builder.Property(e => e.CreateById).IsRequired().HasMaxLength(Equipment.MAX_LENGHT_CREATE_BY_ID);
            builder.HasOne(x => x.HireCategory)
                .WithMany(e => e.Equipments)
                .HasForeignKey(e => e.HireCategoryId);
            builder.HasOne(s => s.HireSubCategory)
                .WithMany(e => e.Equipments)
                .HasForeignKey(e => e.HireSubCategoryId);
        }
    }
}
