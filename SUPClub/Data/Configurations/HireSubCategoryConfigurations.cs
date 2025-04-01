using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SUPClub.Data.Entities;
using SUPClub.Models;

namespace SUPClub.Data.Configurations
{
    internal class HireSubCategoryConfigurations : IEntityTypeConfiguration<HireSubCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<HireSubCategoryEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(HireSubCategory.MAX_LENGHT_NAME);
            builder.Property(e => e.CreateById).IsRequired().HasMaxLength(HireSubCategory.MAX_LENGHT_CREATE_BY_ID);
            builder.HasOne(x => x.HireCategory)
                .WithMany(c => c.HireSubCategories)
                .HasForeignKey(k => k.HireCategoryId);
        }
    }
}