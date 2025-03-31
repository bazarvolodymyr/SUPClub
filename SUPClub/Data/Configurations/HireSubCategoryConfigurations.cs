using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SUPClub.Data.Entities;

namespace SUPClub.Data.Configurations
{
    internal class HireSubCategoryConfigurations : IEntityTypeConfiguration<HireSubCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<HireSubCategoryEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.HasOne(x => x.HireCategory)
                .WithMany(c => c.HireSubCategories)
                .HasForeignKey(k => k.HireCategoryId);
        }
    }
}