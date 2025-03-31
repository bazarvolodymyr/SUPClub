using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SUPClub.Data.Entities;

namespace SUPClub.Data.Configurations
{
    public class EquipmentConfigurations : IEntityTypeConfiguration<EquipmentEntity>
    {
        public void Configure(EntityTypeBuilder<EquipmentEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.DescriptionShort).HasMaxLength(3000);
            builder.Property(e => e.Description).HasMaxLength(100000);
            builder.Property(e => e.Photo).HasMaxLength(300);
            builder.HasOne(x => x.HireCategory)
                .WithMany(e => e.Equipments)
                .HasForeignKey(e => e.HireCategoryId);
            builder.HasOne(s => s.HireSubCategory)
                .WithMany(e => e.Equipments)
                .HasForeignKey(e => e.HireSubCategoryId);
        }
    }
}
