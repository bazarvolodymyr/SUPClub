using SUPClub.Models.DTO.HieCategoryDTO;

namespace SUPClub.Services.Abstract
{
    public interface IHireCategoryService
    {
        Task<IEnumerable<HireCategoryInfoVM>> GetAllInfoAsync();
        Task<List<ListCategories>> CategoriesListAsync();
        Task<EditHireCategoryVM?> GetEditModelAsync(int id);
        Task<IEnumerable<ViewHireCategory>> GetActiveViewInfoAsync();
        Task<string?> SaveAsync(EditHireCategoryVM editHireCategoryVM,
                                IFormFile? titleImageFile, string? userId);
        Task<string?> DeleteAsync(int id);
    }
}
