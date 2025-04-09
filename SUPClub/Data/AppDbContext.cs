using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SUPClub.Data.Configurations;
using SUPClub.Data.Entities;

namespace SUPClub.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<HireCategoryEntity> HireCategories { get; set; }
        public DbSet<HireSubCategoryEntity> HireSubCategories { get; set; }
        public DbSet<EquipmentEntity> Equipments { get; set; } 
        public DbSet<ContactEntity> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new HireCategoryConfigurations());
            builder.ApplyConfiguration(new HireSubCategoryConfigurations());
            builder.ApplyConfiguration(new EquipmentConfigurations());
            builder.ApplyConfiguration(new ContactConfigurations());

            string adminName = "admin";
            string roleAdminId = "407BF8AF-8CE1-45E1-9F2A-2270E884ED28";
            string userAdminId = "433D71D7-3843-4EF9-B934-5177D755F545";

            builder.Entity<IdentityRole>().HasData(new IdentityRole()
            {
                Id = roleAdminId,
                Name = adminName,
                NormalizedName = adminName.ToUpper()
            });
            builder.Entity<AppUser>().HasData(new AppUser()
            {
                Id = userAdminId,
                UserName = adminName,
                NormalizedUserName = adminName.ToUpper(),
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = string.Empty,
                PasswordHash = new PasswordHasher<AppUser>()
                    .HashPassword(new AppUser(), adminName)
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>()
            {
                UserId = userAdminId,
                RoleId = roleAdminId,
            });


            base.OnModelCreating(builder);
        }
    }
}
