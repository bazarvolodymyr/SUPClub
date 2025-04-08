using SUPClub.Models.DTO.HieCategoryDTO;

namespace SUPClub.Services.Abstract
{
    public interface IHireCategoryService
    {
        Task<IEnumerable<HireCategoryInfoVM>> GetAllInfoAsync();
        Task<List<CategoryView>> CategoriesListAsync();
        Task<List<CategoryView>> GetActiveCategoriesAsync();
        Task<EditHireCategoryVM?> GetEditModelAsync(int id);
        Task<string?> SaveAsync(EditHireCategoryVM editHireCategoryVM,
                                IFormFile? titleImageFile, string? userId);
        Task<string?> DeleteAsync(int id);
    }
}
