using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SUPClub.Data;
using SUPClub.Data.Entities;
using SUPClub.Data.Mappings;
using SUPClub.Data.Repositories.Abstract;
using SUPClub.Data.Repositories.EntityFramework;
using SUPClub.Infrastructure;
using SUPClub.Services;
using SUPClub.Services.Abstract;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SUPClub"))
        .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning))); 
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "SUPClub";
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/account/login";
    options.AccessDeniedPath = "/admin/accessdenied";
    options.SlidingExpiration = true;
});

builder.Services.AddAutoMapper(typeof(DataBaseMappings));
builder.Services.AddScoped<ImageHandler>();
builder.Services.AddScoped<IHireCategoryRepository, HireCategoryRepositoryEF>();
builder.Services.AddScoped<IHireSubCategoryRepository, HireSubCategoryRepositoryEF>();
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepositoryEF>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();

builder.Services.AddScoped<IHireCategoryService, HireCategoryService>();
builder.Services.AddScoped<IHireSubCategoryService, HireSubCategoryService>();
builder.Services.AddScoped<IEquipmentService, EquipmentService>();
builder.Services.AddScoped<IContactService, ContactService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();
